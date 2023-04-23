using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{

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
