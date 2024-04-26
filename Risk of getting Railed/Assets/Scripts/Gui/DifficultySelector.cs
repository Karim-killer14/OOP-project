using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour {
    [SerializeField] LoadingGuy loadingGuy;
    private Button easyBtn;
    private Button normalBtn;
    private Button hardBtn;
    private Button startBtn;
    private TMPro.TextMeshProUGUI descriptionText;
    private int difficulty = 1;
    private DifficultyProps diffProps;



    private void Awake() {
        GameObject diffPropsObj = GameObject.Find("DIFF_PROPS");
        if (!diffPropsObj) {
            diffPropsObj = new GameObject("DIFF_PROPS");

            diffProps = diffPropsObj.AddComponent<DifficultyProps>();
            DontDestroyOnLoad(diffPropsObj);
        }
        if (!diffProps) diffProps = diffPropsObj.GetComponent<DifficultyProps>();
    }

    void Start() {
        easyBtn = transform.Find("Drizzle").GetComponent<Button>();
        normalBtn = transform.Find("RainStorm").GetComponent<Button>();
        hardBtn = transform.Find("Monsoon").GetComponent<Button>();
        startBtn = transform.Find("StartGame").GetComponent<Button>();
        descriptionText = transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>();

        easyBtn.onClick.AddListener(() => {
            SetDifficulty(1, new Color(0, 255, 0), "Drizzle is for those who have severe skill issue and want a baby mode, if you're a baby then this is the mode for you :) \n\nDifficulty Effect : All enemies are weaker (duh)");
        });

        normalBtn.onClick.AddListener(() => {
            SetDifficulty(2, new Color (255, 199, 32), "RainStorm is the Base difficulty and its the intended way for this game to be played, if you're new to the game this is the mode for you.\n\nDifficulty Effect : Everything is normal.");
        });

        hardBtn.onClick.AddListener(() => {
            SetDifficulty(3, new Color(255, 0, 0), "Monsoon is.... Hell and you will be screaming, Straight up don't play this if it's your first time (unless you hate yourself)\n\nDifficulty Effect : x2 Enemy Health and x1.5 enemy strength \n\nGood luck, you will need it");
        });

        startBtn.onClick.AddListener(() => {
            Debug.Log($"Hello World {difficulty}");
            loadingGuy.LoadScene(2);
        });
    }

    void SetDifficulty(int difficultyId, Color color, string description) {
        this.difficulty = difficultyId;
        descriptionText.text = description;
        descriptionText.color = color;

        if (difficulty == 1) {
            diffProps.EnemyAttackMultiplier = 0.6f;
            diffProps.PlrAttackMultiplier = 1.5f;
        }
        else if (difficulty == 2) {
            diffProps.EnemyAttackMultiplier = 1;
            diffProps.PlrAttackMultiplier = 1;
        }
        else if (difficulty == 1) {
            diffProps.EnemyAttackMultiplier = 1.5f;
            diffProps.PlrAttackMultiplier = 0.9f;
        }
    }
}
