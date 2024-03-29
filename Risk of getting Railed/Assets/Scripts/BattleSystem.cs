using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WAIT }

public class BattleSystem : MonoBehaviour {
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject moveBtnPrefab;
    [SerializeField] GameObject buffBtnPrefab;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject MainGUI;
    [SerializeField] Transform movesHolder;
    [SerializeField] float ground = -4f;

    private Vector2 PLAYER_POSITION = new(-5, 0);
    private Vector2 ENEMY_POSITION = new(5, 0);

    private Unit playerUnit;
    private Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    void Start() {
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);

        PLAYER_POSITION.y = ground + playerPrefab.transform.localScale.y * 0.5f; // TODO UPDATE THOSE RELATIVELY TO SIZING
        ENEMY_POSITION.y = ground + enemyPrefab.transform.localScale.y * 0.5f;
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
            state = BattleState.WAIT;
            StartCoroutine(WonGame());
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
        yield return new WaitForSeconds(1f);
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

    IEnumerator WonGame() {
        MainGUI.SetActive(false);
        yield return new WaitForSeconds(2f);
        // buff screen now
        WinScreen.SetActive(true);
        Transform buffsHolder = WinScreen.transform.Find("Canvas/BuffsHolder");

        Buff[] options = new Buff[1];
        options[0] = new IncreaseDmg(100);

        foreach (var buff in options) {
            GameObject obj = Instantiate(buffBtnPrefab);
            obj.transform.SetParent(buffsHolder);

            Button btn = obj.GetComponentInChildren<Button>();

            obj.GetComponentInChildren<TextMeshProUGUI>().text = buff.desc;

            btn.onClick.AddListener(() => {
                buff.Perform(playerUnit);
            });
        }
    }
}