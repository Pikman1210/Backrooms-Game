using UnityEngine;

public class ArrowPoint : MonoBehaviour
{

    public Transform doorTransform;

    [SerializeField]
    private Vector3 door;

    private void Update()
    {
        door.x = doorTransform.position.x;
        door.y = doorTransform.position.y; // Saves the door's transform as vector3
        door.z = doorTransform.position.z;

        if (door.y < 2.3f)
        {
            door += new Vector3(0, 2.3f, 0); // Adds some height so it looks good
        }

        transform.LookAt(door); // Looks at the door
    }
}
