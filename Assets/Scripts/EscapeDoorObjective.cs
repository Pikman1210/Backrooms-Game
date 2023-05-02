using UnityEngine;
using TMPro;

public class EscapeDoorObjective : MonoBehaviour
{
    public GameObject completionUI;
    public GameObject failureUI;

    public void EndGameObjective()
    {
        FindObjectOfType<MonsterController>().DisableMonster();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            FindObjectOfType<MonsterController>().DisableMonster();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
