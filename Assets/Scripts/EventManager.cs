using UnityEngine;
using UnityEngine.SceneManagement;
using QFSW.QC;

public class EventManager : MonoBehaviour
{
    public delegate void EscapeEventSurvival(bool active);
    public static event EscapeEventSurvival PanicSurvival; // Defining event

    [Command("panic", "enable/disable escape")]
    public void Panic (bool active) // Escape event for survival
    {
        switch (SceneManager.GetActiveScene().buildIndex) // Checks current scene and does things depending on scene index
        {
            case 0: // Main Menu
                break;
            case 1: // Survival Mode
                PanicSurvival(active);
                break;
            case 2: // Exploration/No Monster Mode
                break;
            case 3: // Objective Mode
                break;
            case 4: // Endless Mode
                break;
            default:
                Debug.LogWarning("EventManager: Scene specific code using fallback");
                break;
        }
    }

    // testing only be sure to remove
    private void OnGUI()
    {
        if (Debug.isDebugBuild)
        {
            if (GUI.Button(new Rect(Screen.width / 3 - 50, 5, 100, 30), "Escape"))
            {
                PanicSurvival(true);
            } 
            else if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "No Escape"))
            {
                PanicSurvival(false);
            }
        }
    }
}
