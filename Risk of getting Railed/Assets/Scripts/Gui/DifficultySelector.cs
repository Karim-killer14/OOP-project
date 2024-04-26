using TMPro;
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
        GameObject diffPropsObj = GameObject.Find("DIFFICULTY_PROPERTIES");
        if (!diffPropsObj) {
            diffPropsObj = new GameObject("DIFFICULTY_PROPERTIES");

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
            SetDifficulty(1, new Color32(0x73, 0xFF, 0x57, 0xFF), new Color32(0x46, 0xAC, 0x41, 0xFF), "Drizzle is for those who have severe skill issue and want a baby mode, if you're a baby then this is the mode for you :) \n\nDifficulty Effect : All enemies are weaker (duh)");
        });

        normalBtn.onClick.AddListener(() => {
            SetDifficulty(2, new Color32(0xFF, 0xC7, 0x57, 0xFF), new Color32(0xFF, 0x9C, 0x21, 0xFF), "RainStorm is the Base difficulty and its the intended way for this game to be played, if you're new to the game this is the mode for you.\n\nDifficulty Effect : Everything is normal.");
        });

        hardBtn.onClick.AddListener(() => {
            SetDifficulty(3, new Color32(0xF7, 0x51, 0x37, 0xFF), new Color32(0xBA, 0x00, 0x00, 0xFF), "Monsoon is.... Hell and you will be screaming, Straight up don't play this if it's your first time (unless you hate yourself)\n\nDifficulty Effect : x2 Enemy Health and x1.5 enemy strength \n\nGood luck, you will need it");
        });

        startBtn.onClick.AddListener(() => {
            Debug.Log($"Hello World {difficulty}");
            loadingGuy.LoadScene(2);
        });
    }


    void SetDifficulty(int difficultyId, Color32 startColor, Color32 endColor, string description) {
        this.difficulty = difficultyId;
        descriptionText.text = description;

        VertexGradient colorGradient = new VertexGradient(startColor, startColor, endColor, endColor);
        descriptionText.colorGradient = colorGradient;

        if (difficulty == 1) {
            diffProps.EnemyAtkMult = 0.6f;
            diffProps.PlrAtkMult = 1.5f;
        }
        else if (difficulty == 2) {
            diffProps.EnemyAtkMult = 1;
            diffProps.PlrAtkMult = 1;
        }
        else if (difficulty == 3) {
            diffProps.EnemyAtkMult = 1.5f;
            diffProps.PlrAtkMult = 0.9f;
        }
    }
}
