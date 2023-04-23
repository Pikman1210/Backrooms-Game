using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{

    [SerializeField]
    private Vector3[] spawnPoints;

    [SerializeField]
    [Tooltip("Corresponds to the respective element number of spawn point")]
    private Quaternion[] rotationSets; // Replace with if statement where if index _ (ones that need rotation)
    // then rotate by 90 degrees  (0, 3, 6, 8, 9, 18)
    // these need 270 degrees (5, 19)
    // these need 180 (10, 12, 13, 17)

    private void Start()
    {
        // Code for spawning and disabiling (visually and colliders) and random spawn here
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
