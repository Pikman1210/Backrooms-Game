using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{

    private Vector3 setSpawnArea;
    private Quaternion setRotation;

    [SerializeField]
    private Vector3[] spawnPoints;

    [SerializeField]
    [Tooltip("Corresponds to the respective element number of spawn point")]
    private Quaternion[] rotationSets; // Replace with if statement where if index _ (ones that need rotation)
    // then rotate by 90 degrees  (0, 3, 6, 8, 9, 18)
    // these need 270 degrees (5, 19)
    // these need 180 (10, 12, 13, 17)

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
            Debug.Log("Escaped!");
            FindObjectOfType<MonsterController>().DisableMonster();
        }
    }
}
