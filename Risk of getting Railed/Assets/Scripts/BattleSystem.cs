using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WAIT }

public class BattleSystem : MonoBehaviour {
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;

    private Vector2 PLAYER_POSITION = new(-4.39f, -2.14f);
    private Vector2 ENEMY_POSITION = new(5.89f, -3.1f);

    private Unit playerUnit;
    private Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    void Start() {
        state = BattleState.START;

        GameObject playerGO = Instantiate(playerPrefab);
        playerGO.transform.position = PLAYER_POSITION;
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyGO.transform.position = ENEMY_POSITION;
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        playerUnit.enemy = enemyUnit;
        playerUnit.animator = playerUnit.GetComponent<Animator>();

        enemyUnit.enemy = playerUnit;
        enemyUnit.animator = enemyUnit.GetComponent<Animator>();

        state = BattleState.PLAYERTURN;
    }

    private void Update() {
        if (state == BattleState.ENEMYTURN) {
            // todo grey out the buttons
            state = BattleState.WAIT;
            StartCoroutine(EnemyTurn());
        }
        else if (state == BattleState.PLAYERTURN) {
            // todo ungrey the buttons
        }
        else if (state == BattleState.LOST) {
            Debug.Log("TODO HANDLE LOSING");

            state = BattleState.WAIT;
        }
        else if (state == BattleState.WON) {
            Debug.Log("TODO HANDLE WINNING");
            state = BattleState.WAIT;
        }
    }

    private void SwitchTurns() {
        if (enemyUnit.CurrentHP <= 0) state = BattleState.WON;
        else if (playerUnit.CurrentHP <= 0) state = BattleState.LOST;
        else state = state == BattleState.PLAYERTURN ? BattleState.ENEMYTURN : BattleState.PLAYERTURN;
    }


    IEnumerator EnemyTurn() {
        // todo add some ai stuff or randomization for the attack id here
        yield return new WaitForSeconds(1f);
        enemyUnit.Attack(0);
        playerHUD.SetHP(playerUnit.CurrentHP);
        SwitchTurns();
    }


    IEnumerator PlayerHeal() {
        // playerUnit.Heal(15, playerUnit.MaxHP);

        // playerHUD.SetHP(playerUnit.CurrentHP);
        yield return new WaitForSeconds(2f);

        // state = BattleState.ENEMYTURN;
        // StartCoroutine(EnemyTurn());
    }


    public void OnAttackButton() {
        if (state != BattleState.PLAYERTURN)
            return;

        playerUnit.Attack(0);
        enemyHUD.SetHP(enemyUnit.CurrentHP);
        SwitchTurns();
    }

    public void OnHealButton() {
        if (state != BattleState.PLAYERTURN)
            return;

        playerUnit.Heal(100);
        playerHUD.SetHP(playerUnit.CurrentHP);
        SwitchTurns();
    }
}