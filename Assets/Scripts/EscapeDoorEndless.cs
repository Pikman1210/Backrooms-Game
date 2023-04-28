using UnityEngine;
using TMPro;

public class EscapeDoorEndless : MonoBehaviour
{
    public GameObject completionUI;
    public GameObject failureUI;
    public TextMeshProUGUI timeSurvivedText;
    public TextMeshProUGUI timeSurvivedTextFailure;

    private float timeSurvived;

    public void EndGameEndless()
    {
        FindObjectOfType<MonsterController>().DisableMonster();

        timeSurvived = PlayerPrefs.GetFloat("timeSurvived");

        failureUI.SetActive(true);
        timeSurvivedTextFailure.SetText(timeSurvived.ToString());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            FindObjectOfType<Stopwatch>().stopStopwatch();
            FindObjectOfType<MonsterController>().DisableMonster();

            timeSurvived = PlayerPrefs.GetFloat("timeSurvived");

            completionUI.SetActive(true);
            timeSurvivedText.SetText(timeSurvived.ToString());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
