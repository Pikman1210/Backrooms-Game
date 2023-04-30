#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GeneralEditorWindow : EditorWindow {
    /*
    string sceneName = SceneManager.GetActiveScene().name;
    int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    bool sceneLoaded = SceneManager.GetActiveScene().isLoaded;
    string scenePath = SceneManager.GetActiveScene().path;
    */
    [MenuItem("Window/Useful Things")]
    public static void ShowWindow()
    {
        GetWindow<GeneralEditorWindow>("Useful Things");
    }

    private void OnGUI ()
    {
        GUILayout.Label("Current Scene:", EditorStyles.boldLabel);

        EditorGUILayout.Space();
        /*
        GUILayout.Label("Name: " + sceneName);
        GUILayout.Label("Build Index: " + sceneBuildIndex);
        GUILayout.Label("Is Loaded: " + sceneLoaded);
        GUILayout.Label("Scene path: " + scenePath);*/
    }

}

#endif