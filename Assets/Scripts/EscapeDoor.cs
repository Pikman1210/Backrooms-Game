using UnityEngine;
using Unity.Services.Analytics;

public class EscapeDoor : MonoBehaviour
{
    public GameObject completionUI;

    private Vector3 setSpawnArea;
    private Quaternion setRotation;

    [SerializeField]
    private Vector3[] spawnPoints;

    [SerializeField]
    [Tooltip("Corresponds to the respective element number of spawn point")]
    private Quaternion[] rotationSets;

    public void EscapeDoorSpawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length); // Gets a random set from the possible locations
        setSpawnArea = spawnPoints[spawnIndex]; // Sets a Vector3 using the random location

        transform.localPosition = setSpawnArea; // Sets the door's position

        setRotation = rotationSets[spawnIndex]; // Sets a Quaternion using the random location

        transform.localRotation = setRotation; // Sets the door's rotation

        Physics.SyncTransforms(); // Makes sure the transform gets fully updated
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AnalyticsService.Instance.CustomData("survivalEscape");

            FindObjectOfType<MonsterController>().DisableMonster();
            FindObjectOfType<AudioManager>().Stop("EscapeMusic");
            completionUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void DespawnDoor()
    {
        transform.localPosition = new Vector3(0, -10, 0);
        Physics.SyncTransforms();
    }
}
