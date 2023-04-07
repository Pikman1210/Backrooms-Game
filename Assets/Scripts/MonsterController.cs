using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour {

    public Transform player;
    public NavMeshAgent agent;

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            FindObjectOfType<GameManager>().Restart();
        }
    }

}
