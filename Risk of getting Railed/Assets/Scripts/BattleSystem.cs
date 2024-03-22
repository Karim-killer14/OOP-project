using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WAIT }

public class BattleSystem : MonoBehaviour {
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject moveBtnPrefab;
    [SerializeField] Transform movesHolder;

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

        LoadPlayerMoves();
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
        enemyHUD.SetHP(enemyUnit.CurrentHP);
        playerHUD.SetHP(playerUnit.CurrentHP);

        if (enemyUnit.CurrentHP <= 0) state = BattleState.WON;
        else if (playerUnit.CurrentHP <= 0) state = BattleState.LOST;
        else state = state == BattleState.PLAYERTURN ? BattleState.ENEMYTURN : BattleState.PLAYERTURN;
    }


    IEnumerator EnemyTurn() {
        // todo add some ai stuff or randomization for the attack id here
        yield return new WaitForSeconds(1f);
        Debug.Log("ENEMY ATTACKED BROOOOOO0O LETS FRICKEN GO");
        // enemyUnit.Attack(0);
        playerHUD.SetHP(playerUnit.CurrentHP);
        SwitchTurns();
    }

    void LoadPlayerMoves() {
        foreach (Move move in playerUnit.moves) {
            GameObject Obj = Instantiate(moveBtnPrefab);
            Obj.transform.SetParent(movesHolder);
            TextMeshProUGUI txt = Obj.GetComponentInChildren<TextMeshProUGUI>();
            if (txt) txt.text = $"{move.attackName}";

            Button btn = Obj.GetComponent<Button>();
            btn.onClick.AddListener(() => {
                if (state != BattleState.PLAYERTURN)
                    return;

                move.Perform(playerUnit);
                SwitchTurns();
            });
        }

    }
}