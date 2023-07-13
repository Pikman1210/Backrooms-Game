using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Unity.Services.Analytics;
using System.Collections.Generic;
using QFSW.QC;

public class GameManager : MonoBehaviour {

    // public static GameManager instance { get; private set; }

    public GameObject DevBuildText;
    public GameObject PlayTestUI;
    public GameObject player;

    public Transform[] playerSpawns;

    [SerializeField]
    private Vector3 minPosition;

    [SerializeField]
    private Vector3 maxPosition;

    private async void Awake()
    {
        /*if (instance != null && instance != this)
        {
            Destroy(this);
        } 
        else
        {
            instance = this;
        }*/

        if (Debug.isDebugBuild)
        {
            var options = new InitializationOptions();
            options.SetEnvironmentName("dev");
            await UnityServices.InitializeAsync(options);
        } else {
            var options = new InitializationOptions();
            options.SetEnvironmentName("production");
            await UnityServices.InitializeAsync(options);
        }
        
    }

    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync(); // Intialize analytics SDK
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        }
        catch (ConsentCheckException e)
        {
            Debug.LogError(e); // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
        }

        // Checks if the current build is a Development Build (always true in editor)
        if (Debug.isDebugBuild && SceneManager.GetActiveScene().buildIndex == 0) // Only for Main Menu
        {
            DevBuildText.SetActive(true);
            PlayTestUI.SetActive(true);
        } else if (Debug.isDebugBuild && SceneManager.GetActiveScene().name != "Testing 1")
        {
            DevBuildText.SetActive(true);
        }

        switch(SceneManager.GetActiveScene().buildIndex) // Checks current scene and does things depending on scene index
        {
            case 0: // Main Menu
                break;
            case 1: // Survival Mode
                FindObjectOfType<Timer>().StartTimer();
                PlayerRandomSpawn();
                break;
            case 2: // Exploration/No Monster Mode
                break;
            case 3: // Objective Mode
                FindObjectOfType<Timer>().StartTimer();
                break;
            case 4: // Endless Mode
                PlayerRandomSpawn();
                FindObjectOfType<Stopwatch>().startStopwatch();
                break;
            default:
                Debug.LogWarning("Scene specific code using fallback");
                break;
        }

    }

    private void PlayerRandomSpawn()
    {
        Cursor.visible = false; // Makes cursor invisible to fix cursor visible bug, make sure to reenable for menus

        // Chooses random area in the maze to spawn player
        Vector3 spawnLocation = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            0,
            Random.Range(minPosition.z, maxPosition.z)
        );

        // Moves player to the selected spawn point
        player.transform.localPosition = spawnLocation;

        // Applies the transform immediatly
        Physics.SyncTransforms();
    }

    public void Restart()
    {
        // FindObjectOfType<LevelLoader>().LoadLevel(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Loads current scene, effectively restarting it
    }
    
    /*[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void OnBeforeSplashScreen()
    {
        // any code that should be run before the "Made with Unity" splash screen
    } */
}
