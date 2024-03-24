using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingGuy : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progressText;
    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {

            float progressvalue = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progressvalue;
            
            progressText.text = progressvalue *100f + "%";

            yield return null;
        }
    }

}
