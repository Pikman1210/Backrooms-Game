using UnityEngine;
using UnityEngine.AI;
using Unity.Services.Analytics;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour {

    public Transform player;
    public NavMeshAgent agent;
    // public Transform[] points;

    // private int destPoint = 0;

    Dictionary<string, object> parameters = new Dictionary<string, object>()
    {
        {"timeAlive", 0f}, // Change to actually get the amount of time alive instead of 0
    };

    /*private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }*/

    private void Update()
    {
        agent.SetDestination(player.position);

        /*if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }*/
    }

    /*private void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length; // Replace with a random instead of linear
    } */

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AnalyticsService.Instance.CustomData("died", parameters);
            FindObjectOfType<GameManager>().Restart();
        }
    }

}
