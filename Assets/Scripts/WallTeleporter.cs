using UnityEngine;

public class WallTeleporter : MonoBehaviour {

    public GameObject player;

    [SerializeField]
    private int DestinationIndex;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Teleport(DestinationIndex);
        }
    }

    public void Teleport (int destination)
    {
        switch (destination)
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
        }

        Physics.SyncTransforms(); // Super important, actually makes the transform happen!
    }
}
