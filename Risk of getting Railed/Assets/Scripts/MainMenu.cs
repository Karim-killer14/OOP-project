using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public void Selector()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
