using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Single Player/Objective Data", fileName = "New Objective Data")]
public class ObjectiveData : ScriptableObject
{
    public int spawnLocation;
    // 1 number out of 30 depending on spawn location, so it won't be 1,2,3
    // it would probably end up being more like 5, 2, 7
    public bool collected = false; 
    // Defaults to not collected
}
