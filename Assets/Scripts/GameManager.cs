using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    // bool gameHasEnded = false;
    public GameObject DevBuildText;
    public GameObject PlayTestUI;

    void Start()
    {
        // Checks if the current build is a Development Build (always true in editor)
        if (Debug.isDebugBuild && SceneManager.GetActiveScene().buildIndex == 0) // Only for Main Menu
        {
            DevBuildText.SetActive(true);
            PlayTestUI.SetActive(true);
        } else if (true)
        {
            DevBuildText.SetActive(true);
        }
    }

    void Update()
    {
        
    }

    public void Restart()
    {
        // FindObjectOfType<LevelLoader>().LoadLevel(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Loads current scene, effectively restarting it
    }
}
