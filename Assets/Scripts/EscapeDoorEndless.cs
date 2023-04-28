using UnityEngine;
using TMPro;

public class EscapeDoorEndless : MonoBehaviour
{
    public GameObject completionUI;
    public GameObject failureUI;
    public TextMeshProUGUI timeSurvivedText;
    public TextMeshProUGUI timeSurvivedTextFailure;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI highscoreTextFailure;

    private float timeSurvived;
    private float highscore;

    public void EndGameEndless()
    {
        FindObjectOfType<MonsterController>().DisableMonster();

        timeSurvived = PlayerPrefs.GetFloat("timeSurvived");
        highscore = PlayerPrefs.GetFloat("endlessHighscore");

        if (timeSurvived > highscore)
        {
            PlayerPrefs.SetFloat("endlessHighscore", timeSurvived);
        }
        highscore = PlayerPrefs.GetFloat("endlessHighscore");

        failureUI.SetActive(true);
        timeSurvivedTextFailure.SetText(timeSurvived.ToString());
        highscoreTextFailure.SetText(highscore.ToString());
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
            highscore = PlayerPrefs.GetFloat("endlessHighscore");

            if (timeSurvived > highscore)
            {
                PlayerPrefs.SetFloat("endlessHighscore", timeSurvived);
            }
            highscore = PlayerPrefs.GetFloat("endlessHighscore");

            completionUI.SetActive(true);
            timeSurvivedText.SetText(timeSurvived.ToString());
            highscoreText.SetText(highscore.ToString());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
