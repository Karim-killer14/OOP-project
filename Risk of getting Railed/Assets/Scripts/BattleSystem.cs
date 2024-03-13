using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour {

    [SerializeField] Animator playerAnim;
    [SerializeField] Animator enemyAnim;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    // Start is called before the first frame update
    void Start() {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack() {
        int attackID = UnityEngine.Random.Range(1, 3);

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        playerAnim.SetTrigger($"attack{attackID}");

        enemyHUD.SetHP(enemyUnit.CurrentHP);

        yield return new WaitForSeconds(0.2f);
        enemyAnim.SetTrigger("takeHit");
        yield return new WaitForSeconds(0.5f);

        if (isDead) {
            state = BattleState.WON;
            EndBattle();
        }
        else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn() {
        yield return new WaitForSeconds(0.5f);
        int attackID = UnityEngine.Random.Range(1, 2);
        enemyAnim.SetTrigger($"attack{attackID}");
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        yield return new WaitForSeconds(0.2f);
        playerAnim.SetTrigger("takeHit");
        playerHUD.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(0.5f);

        if (isDead) {
            state = BattleState.LOST;
            EndBattle();
        }
        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void EndBattle() {
        if (state == BattleState.WON) {
            enemyAnim.SetTrigger("dead");
        }
        else if (state == BattleState.LOST) {
            playerAnim.SetTrigger("dead");
        }
    }

    void PlayerTurn() {
    }

    IEnumerator PlayerHeal() {
        playerUnit.Heal(15, playerUnit.MaxHP);

        playerHUD.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton() {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton() {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

}