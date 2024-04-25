using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingGuy : MonoBehaviour {
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progressText;
    public void LoadScene(int sceneID) {
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    IEnumerator LoadSceneAsync(int sceneID) {
        GameObject winScreen = GameObject.Find("WinScreen");
        GameObject loseScreen = GameObject.Find("LoseScreen");
        if (winScreen) winScreen.SetActive(false);
        if (loseScreen) loseScreen.SetActive(false);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);


        LoadingScreen.SetActive(true);

        while (!operation.isDone) {

            float progressvalue = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progressvalue;

            progressText.text = progressvalue * 100f + "%";

            yield return null;
        }
    }

}
