using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Unity.Services.Analytics;
using System;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour {

    public GameObject DevBuildText;
    public GameObject PlayTestUI;

    async void Awake()
    {
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
        } else if (Debug.isDebugBuild)
        {
            DevBuildText.SetActive(true);
        }

        switch(SceneManager.GetActiveScene().buildIndex) // Checks current scene and does things depending on scene index
        {
            case 0:
                Debug.Log("menu");
                break;
            case 1:
                Debug.Log("survival timed");
                Cursor.visible = false; // Makes cursor invisible to fix cursor visible bug, make sure to reenable for menus
                break;
            default:
                Debug.LogWarning("Scene specific code using fallback");
                break;
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