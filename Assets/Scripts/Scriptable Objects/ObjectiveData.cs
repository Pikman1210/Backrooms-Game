using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Single Player/Objective Data", fileName = "New Objective Data")]
public class ObjectiveData : ScriptableObject
{
    public GameObject objectivePrefab;

    public GameObject[] objectiveObjects;

    public int totalObjectives;
    public int collectedObjectives;
}
