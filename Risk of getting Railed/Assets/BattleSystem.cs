using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START ,PLAYERTURN ,ENEMYTURN ,WIN ,LOSS }

public class BattleSystem : MonoBehaviour
{

    public GameObject Player;
    public GameObject Enemy;

    public Transform PlayerStats;
    public Transform EnemyStats;

    public BattleState state;

    Unit PlayerUnit;
    Unit EnemyUnit;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(setupBattle());
    }

    IEnumerator setupBattle()
    {
        GameObject PlayerGO = Instantiate(Player, PlayerStats);
        PlayerUnit = PlayerGO.GetComponent<Unit>();

        GameObject EnemyGO = Instantiate(Enemy, EnemyStats);
        EnemyUnit = EnemyGO.GetComponent<Unit>();

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {

    }

    IEnumerator PlayerAttack()
    {
        bool isDead = EnemyUnit.TakeDamage(PlayerUnit.damage);

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        //UI update
        yield return new WaitForSeconds(1f);

        bool isDead = PlayerUnit.TakeDamage(EnemyUnit.damage);
        //UI update
        yield return new WaitForSeconds(1f);

        if (isDead) 
        {
            state = BattleState.LOSS;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WIN)
        {
            // UI/Scene transition(i assume)
        }else if( state == BattleState.LOSS)
        {
            // UI/Scene transition(i assume)
        }

    }

    IEnumerator PlayerHeal()
    {
        PlayerUnit.Heal(15);

        yield return new WaitForSeconds(1f);
    }

    public void onAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack()); 
    }
}