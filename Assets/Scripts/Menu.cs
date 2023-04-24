using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Services.Analytics;
using TMPro;

public class Menu : MonoBehaviour {

    public AudioMixer audioMixer;
    public LevelLoader levelLoader;

    // Variables for settings
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    // Panels
    public GameObject WelcomePanelObject;
    public GameObject OptionsPanelObject;
    public GameObject LoadingPanelObject;

    // Analytics Parameters
    // Here be dragons!

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions(); // clears placeholders in dropdown

        List<string> options = new List<string>();

        int currentResolutionIndex = 0; // loops through possible resolutions and hz and adds them to array to add to dropdown
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Main Menu
    public void StartSurvivalMode ()
    {
        AnalyticsService.Instance.CustomData("loadedSurvivalMode"); // Sends the event message of starting survival mode
        AnalyticsService.Instance.Flush(); // (Optional) Forces event to send immediately

        levelLoader = FindObjectOfType<LevelLoader>();
        levelLoader.LoadLevel(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    // Settings Menu

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
