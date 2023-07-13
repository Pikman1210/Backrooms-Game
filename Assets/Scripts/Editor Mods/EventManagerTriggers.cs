#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventManager))]
public class EventManagerTriggers : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Keeps the original code so I can add

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Start Escape")) // Only happens when button pressed
        {
            FindObjectOfType<EventManager>().Panic(true);
        }

        if (GUILayout.Button("Stop Escape"))
        {
            FindObjectOfType<EventManager>().Panic(false);
        }

        GUILayout.EndHorizontal();
    }
}

#endif