using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Deactivates pause screen
        Time.timeScale = 1f; // Unpauses the game
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        GameIsPaused = false; // Changing static boolean
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Activates pause screen
        Time.timeScale = 0f; // Pauses the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true; // Changing static boolean
    }

    public void Restart()
    {
        FindObjectOfType<GameManager>().Restart(); // Reloads the scene
        Time.timeScale = 1f; // Unpauses the game
        Cursor.lockState = CursorLockMode.Confined; // Confines cursor to window
        Cursor.visible = false; // Makes the cursor invisible
        GameIsPaused = false; // Changing static boolean
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0); // Loads the main menu
        Time.timeScale = 1f; // Unpauses the game
        Cursor.lockState = CursorLockMode.None; // Unlocks cursor
        Cursor.visible = true; // Makes the cursor visible
        GameIsPaused = false; // Changing static boolean
    }

    public void QuitToOS()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit(); // Quits the game normally
#endif
    }

}
