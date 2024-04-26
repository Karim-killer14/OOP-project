using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour {
    [SerializeField] LoadingGuy loadingGuy;
    private Button easyBtn;
    private Button normalBtn;
    private Button hardBtn;
    private Button startBtn;
    private TMPro.TextMeshProUGUI descriptionText;
    public int difficulty = 1;
    public static DifficultySelector Instance;

    void Start() {
        easyBtn = transform.Find("Drizzle").GetComponent<Button>();
        normalBtn = transform.Find("RainStorm").GetComponent<Button>();
        hardBtn = transform.Find("Monsoon").GetComponent<Button>();
        startBtn = transform.Find("StartGame").GetComponent<Button>();
        descriptionText = transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>();

        easyBtn.onClick.AddListener(() => {
            SetDifficulty(1, new Color(70, 172, 65), "Drizzle is for those who have severe skill issue and want a baby mode, if you're a baby then this is the mode for you :) \n\nDifficulty Effect : All enemies are weaker (duh)");
        });

        normalBtn.onClick.AddListener(() => {
            SetDifficulty(2, new Color(255, 156, 33), "RainStorm is the Base difficulty and its the intended way for this game to be played, if you're new to the game this is the mode for you.\n\nDifficulty Effect : Everything is normal.");
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
    }
}
