#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterController))]
public class MonsterCustomEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Keeps the original code so I can add stuff instead of yeetus deletus

        MonsterController monster = (MonsterController)target;

        EditorGUILayout.Space(); // Visual space, makes it look nice :)
        EditorGUILayout.LabelField("Monster Status", EditorStyles.boldLabel);

        bool isChasing = monster.chasing;
        bool isPatrolling = monster.patrolling;

        if (isChasing == true)
        {
            EditorGUILayout.LabelField("Chasing");
        } else if (isPatrolling == true)
        {
            EditorGUILayout.LabelField("Patrolling");
        }
        else
        {
            EditorGUILayout.LabelField("Disabled");
        }

        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Chase Player")) // Only happens when button pressed
        {
            monster.ChasePlayer();
        }

        if (GUILayout.Button("Stop Chase"))
        {
            monster.StopChasePlayer();
        }

        GUILayout.EndHorizontal();

        if (GUILayout.Button("Enable Monster"))
        {
            monster.EnableMonster();
        }

        if (GUILayout.Button("Disable Monster"))
        {
            monster.DisableMonster();
        }
    }
}

#endif