#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

public class GeneralEditorWindow : EditorWindow {

    public string newName;

    private int nameCount;

    [MenuItem("Window/Useful Things")]
    public static void ShowWindow()
    {
        GetWindow<GeneralEditorWindow>("Useful Things");
    }

    private void OnGUI ()
    {
        GUILayout.Label("Rename " + Selection.gameObjects.Length + " selected objects", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        newName = EditorGUILayout.TextField("New Name", newName);

        EditorGUILayout.Space();

        if (GUILayout.Button("Rename"))
        {
            foreach(GameObject obj in Selection.gameObjects)
            {
                obj.name = newName + nameCount;
                nameCount++;
            }

            nameCount = 0;
        }
    }

}

#endif