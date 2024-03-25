using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WAIT }

public class BattleSystem : MonoBehaviour {
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject moveBtnPrefab;
    [SerializeField] GameObject WinScreen;//
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject MainGUI;
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
            MainGUI.SetActive(false);
            LoseScreen.SetActive(true);
        }
        else if (state == BattleState.WON) {
            MainGUI.SetActive(false);
            WinScreen.SetActive(true);
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
        yield return new WaitForSeconds(1f);
        enemyUnit.aiAttack();
        enemyUnit.IncrementCooldown();

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

                if (!move.Perform(playerUnit)) return;

                playerUnit.IncrementCooldown();
                SwitchTurns();
            });
        }

    }
}