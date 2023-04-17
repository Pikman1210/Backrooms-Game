using UnityEngine;
using UnityEngine.AI;
using Unity.Services.Analytics;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour {

    public Transform player;
    public NavMeshAgent agent;
    public Transform[] points;

    [Tooltip("How many meters/units")]
    public float agroRange; // Default 10

    [Tooltip("How many meters player needs to be away before chase patrols resume")]
    public float chaseEndRange; // Default 20

    private int destPoint = 0;
    private bool chasing = false;
    private IEnumerator chaseLoop;

    [SerializeField]
    private float patrolSpeed = 4;

    [SerializeField]
    private float chaseSpeed = 6; // 5.5 or 6 work (6 prob better idk yet)

    Dictionary<string, object> parameters = new Dictionary<string, object>()
    {
        {"timeAlive", 0f}, // Change to actually get the amount of time alive instead of 0
    };

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < agroRange && chasing == false)
        {
            chasing = true;
            GetComponent<NavMeshAgent>().speed = chaseSpeed;
            chaseLoop = ChasePlayerCoroutine();
            StartCoroutine(chaseLoop);
            FindObjectOfType<AudioManager>().Play("ChaseScream");

        } else if (distanceToPlayer > chaseEndRange && chasing == true)
        {
            chasing = false;
            GetComponent<NavMeshAgent>().speed = patrolSpeed;
            chaseLoop = ChasePlayerCoroutine();
            StopCoroutine(chaseLoop);
            GotoNextPoint();

        } else if (!agent.pathPending && agent.remainingDistance < 0.5f && chasing == false)
        {
            GotoNextPoint();
        }
    }

    private IEnumerator ChasePlayerCoroutine()
    {
        while (chasing == true)
        {
            agent.SetDestination(player.position);

            // Yield execution of this coroutine and return to the main loop until next frame
            yield return null;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void StopChase()
    {
        agent.SetDestination(gameObject.transform.position); // Sets destination to self, basically cancelling paths
        chasing = false;
        Debug.Log(chasing);
        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Chooses random point to go to
        destPoint = Random.Range(0, 19); // (destPoint + 1) % points.Length;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AnalyticsService.Instance.CustomData("died", parameters);
            FindObjectOfType<GameManager>().Restart();
        }
    }

}
