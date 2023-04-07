using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider progressBar;
    public TMP_Text progressText;

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // loads scene into memory in background as async operation

        loadingScreen.SetActive(true); // enables the loading screen

        while (!operation.isDone) // loops while operation (loading) is NOT done (what the ! means)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); // makes the number look nice i think?

            progressBar.value = progress; // updates slider
            progressText.text = progress * 100f + "%"; // updates text as percent

            yield return null; // waits a frame before repeating
        }
    }

}
