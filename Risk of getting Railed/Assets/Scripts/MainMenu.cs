using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public void playGame() {
        SceneManager.LoadScene(2);
    }
    public void Selector()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
