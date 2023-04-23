using UnityEngine;

public class WallTeleporter : MonoBehaviour {

    public GameObject player;

    [SerializeField]
    private Vector3 minPosition;
    
    [SerializeField]
    private Vector3 maxPosition;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Teleport();
        }
    }

    public void Teleport()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            0,
            Random.Range(minPosition.z, maxPosition.z)
        );

        player.transform.localPosition = randomPosition;

        Physics.SyncTransforms(); // Super important, actually makes the transform happen!
    }
}
