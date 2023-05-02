using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Single Player/Objective Object", fileName = "New Objective")]
public class ObjectiveObject : ScriptableObject
{
    [Tooltip("DO NOT HAVE DUPLICATES")]
    public int ID; // Will be preset
    [SerializeField]
    [Tooltip("Don't edit, for viewing only")]
    private int spawnZone;
    // 1 number out of 30 depending on spawn location, so it won't be 1,2,3
    // it would probably end up being more like 5, 2, 7

    public bool collected = false; // Starts as false obviously
}
