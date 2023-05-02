using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Single Player/Objective Data Manager", fileName = "New Objective Data Manager")]
public class ObjectiveDataManager : ScriptableObject
{
    public GameObject objectivePrefab;
    public GameObject spawnZonePrefab;

    public int totalObjectives;
    public int collectedObjectives;
}
