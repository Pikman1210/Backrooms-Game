using UnityEngine;

public class WallTeleporter : MonoBehaviour {

    public GameObject player;

    [SerializeField]
    private int DestinationIndex;

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

    public void Teleport()//(int destination)
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            0,
            Random.Range(minPosition.z, maxPosition.z)
        );

        player.transform.localPosition = randomPosition;

        /*switch (destination)
        {
            case 0:
                player.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case 1:
                player.transform.localPosition = new Vector3(56, 0, 56);
                break;
            case 2:
                player.transform.localPosition = new Vector3(-23, 0, -46);
                break;
            case 3:
                player.transform.localPosition = new Vector3(-18, 0, 66);
                break;
            case 4:
                player.transform.localPosition = new Vector3(32, 0, -11);
                break;
            default:
                Debug.LogWarning("Wall teleport failed, uh oh");
                break;
        } */

        Physics.SyncTransforms(); // Super important, actually makes the transform happen!
    }
}
