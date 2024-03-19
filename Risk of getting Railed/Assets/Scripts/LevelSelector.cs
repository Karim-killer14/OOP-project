using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
    [SerializeField] GameObject levelHolder;

    void Start() {
        Button[] buttons = levelHolder.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++) {
            int lvlIdx = i + 1;
            buttons[i].onClick.AddListener(() => SceneManager.LoadScene($"Stage{lvlIdx}"));
        }
    }
}