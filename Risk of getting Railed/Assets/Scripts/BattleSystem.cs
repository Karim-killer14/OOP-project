using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WAIT }

public class BattleSystem : MonoBehaviour {
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject moveBtnPrefab;
    [SerializeField] GameObject buffBtnPrefab;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject BuffScreen;
    [SerializeField] float ground = -4f;
    private AudioSource OST;
    private Dictionary<int, GameObject> MoveBtnDict = new();

    Buff[][] buffs = new Buff[][] {
            new Buff[]{}, // sabry level
            new Buff[]{new IncreaseDmg(10), new IncreaseMaxHP(10), new RngAttackDmg(50, 50)}, // rick level
            new Buff[]{}, // fire lord level
            new Buff[]{}, // 
            new Buff[]{},
            new Buff[]{},
            new Buff[]{},
            new Buff[]{},
        };

    private Unit playerUnit;
    private Unit enemyUnit;

    private GameObject MainGUI;
    private Transform movesHolder;
    private BattleHUD playerHUD;
    private BattleHUD enemyHUD;

    public BattleState state;

    private void Awake() {
        OST = GameObject.Find("OST").GetComponent<AudioSource>();
        MainGUI = GameObject.Find("MainGUI");
        playerHUD = MainGUI.transform.Find("PlayerStation/PlayerHUD").GetComponent<BattleHUD>();
        enemyHUD = MainGUI.transform.Find("EnemyStation/EnemyHUD").GetComponent<BattleHUD>();
        movesHolder = MainGUI.transform.Find("PlayerStation/MovesHolder").transform;
    }

    void Start() {
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);

        state = BattleState.START;

        GameObject playerGO = GameObject.Find("Player");
        if (!playerGO) {
            playerGO = Instantiate(playerPrefab);
            playerGO.name = "Player";
            DontDestroyOnLoad(playerGO.gameObject);
        }

        playerUnit = playerGO.GetComponent<Unit>();
        playerGO.transform.position = new Vector2(-5, playerUnit.YPos);
        playerUnit.Reset();

        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyUnit = enemyGO.GetComponent<Unit>();
        enemyGO.transform.position = new Vector2(5, enemyUnit.YPos);

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
            movesHolder.gameObject.SetActive(false);
            state = BattleState.WAIT;
            StartCoroutine(EnemyTurn());
        }
        else if (state == BattleState.PLAYERTURN) {
            movesHolder.gameObject.SetActive(true);
        }
        else if (state == BattleState.LOST) {
            MainGUI.SetActive(false);
            LoseScreen.SetActive(true);
            OST.enabled = false;
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
        for (int i = 0; i < playerUnit.Moves.Length; i++) {
            Move move = playerUnit.Moves[i];
            GameObject obj = Instantiate(moveBtnPrefab);
            MoveBtnDict.Add(i, obj);
            obj.transform.SetParent(movesHolder);
            TextMeshProUGUI titleTxt = obj.transform.Find("TitleTxt").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI cooldownTxt = obj.transform.Find("CooldownTxt").GetComponent<TextMeshProUGUI>();

            titleTxt.text = $"{move.attackName}";
            cooldownTxt.text = $"{move.cooldownLimit - move.Cooldown}";

            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(() => {
                if (state != BattleState.PLAYERTURN)
                    return;

                if (!move.Perform(playerUnit)) return;
                playerUnit.IncrementCooldown();

                foreach ((int moveI, GameObject obj) in MoveBtnDict) {
                    // foreach (KeyValuePair<Move, GameObject> entry in MoveBtnDict) {
                    TextMeshProUGUI cooldownTxt = obj.transform.Find("CooldownTxt").GetComponent<TextMeshProUGUI>();
                    cooldownTxt.text = $"{playerUnit.Moves[moveI].cooldownLimit - playerUnit.Moves[moveI].Cooldown}";
                }

                SwitchTurns();
            });
        }
    }

    [ContextMenu("win")]
    void testWin() {
        StartCoroutine(WonGame());
    }

    IEnumerator WonGame() {
        OST.enabled = false;
        MainGUI.SetActive(false);
        yield return new WaitForSeconds(1.7f);



        int id;
        bool success = int.TryParse(gameObject.tag.Substring(3), out id);

        Buff[] options = { };

        if (success)
            options = buffs[id];

        if (options.Length <= 0) {
            WinScreen.SetActive(true);
        }
        else {
            BuffScreen.SetActive(true);
            Transform buffsHolder = BuffScreen.transform.Find("Canvas/BuffsHolder");

            foreach (var buff in options) {
                GameObject obj = Instantiate(buffBtnPrefab);
                obj.transform.SetParent(buffsHolder);//create btn

                Button btn = obj.GetComponentInChildren<Button>();//get btn

                buff.LoadInfoToUI(obj);

                btn.onClick.AddListener(() => {
                    buff.Perform(playerUnit);

                    BuffScreen.SetActive(false);
                    WinScreen.SetActive(true);
                });
            }
        }
    }
}