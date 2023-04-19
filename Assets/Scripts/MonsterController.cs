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
    private bool escapeSequence = false;

    private IEnumerator chaseLoop;

    [SerializeField]
    private float patrolSpeed = 4;

    [SerializeField]
    private float chaseSpeed = 6; // 5.5 or 6 work (6 prob better idk yet)

    [SerializeField]
    private float escapeChaseSpeed = 8;

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

        if (distanceToPlayer < agroRange && chasing == false && escapeSequence == false)
        {
            chasing = true;
            GetComponent<NavMeshAgent>().speed = chaseSpeed;
            chaseLoop = ChasePlayerCoroutine();
            StartCoroutine(chaseLoop);
            FindObjectOfType<AudioManager>().Play("ChaseScream");

        } else if (distanceToPlayer > chaseEndRange && chasing == true && escapeSequence == false)
        {
            chasing = false;
            GetComponent<NavMeshAgent>().speed = patrolSpeed;
            chaseLoop = ChasePlayerCoroutine();
            StopCoroutine(chaseLoop);
            GotoNextPoint();

        } else if (!agent.pathPending && agent.remainingDistance < 0.5f && chasing == false && escapeSequence == false)
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
        chasing = false;
        GetComponent<NavMeshAgent>().speed = patrolSpeed;
        chaseLoop = ChasePlayerCoroutine();
        StopCoroutine(chaseLoop);
        GotoNextPoint();
    }

    public void DisableMonster()
    {
        chasing = false;
        chaseLoop = ChasePlayerCoroutine();
        StopCoroutine(chaseLoop);
        agent.SetDestination(gameObject.transform.position);
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }

    private void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Chooses random point to go to
        destPoint = Random.Range(0, 18); // (destPoint + 1) % points.Length;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
    }

    public void EscapeSequence(int levelType) // Level index for different modes
    {
        switch (levelType) // Checks current scene and does things depending on scene index
        {
            case 1: // Survival mode
                Debug.Log("Its pizza time in survival mode");
                GetComponent<NavMeshAgent>().speed = escapeChaseSpeed;
                break;
            case 2:
                Debug.Log("Its pizza time in _ mode");
                break;
            default:
                Debug.LogWarning("Scene specific code using fallback");
                break;
        }
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
