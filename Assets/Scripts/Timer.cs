using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using TMPro;

public class Timer : MonoBehaviour {

    bool timerActive = false;

    float currentTime;

    [Tooltip("Displays as seconds")]
    public int startMinutes;

    public GameObject escapeArrow;
    public TextMeshProUGUI currentTimeText;

    Dictionary<string, object> parameters;

    private int levelIndex;

    void Start()
    {
        currentTime = startMinutes * 60; // stores current time as seconds
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"timeAlive", currentTime},
        };
        startTimer(); // starts as soon as the game begins (maybe change later?)
    }

    void Update()
    {
        if (timerActive == true) // checks if timer is active
        {
            currentTime = currentTime - Time.deltaTime; // decreases time by how many miliseconds since last update
            if (currentTime <= 0) // activates once timer ends
            {
                // Timer visual/analytics code
                timerActive = false;
                currentTimeText.text = "0";
                AnalyticsService.Instance.CustomData("timerEnded", parameters);

                // Escape Sequence code
                levelIndex = SceneManager.GetActiveScene().buildIndex;
                FindObjectOfType<EscapeDoor>().EscapeDoorSpawn();
                escapeArrow.SetActive(true); // Enables the arrow pointing towards the escape
                FindObjectOfType<MonsterController>().EscapeSequence(levelIndex); // Changes monster to escape mode
                FindObjectOfType<ObjectiveController>().UpdateObjective("- ESCAPE!"); // Updates objective
                FindObjectOfType<AudioManager>().Play("EscapeMusic"); // Plays escape music
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        // currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString(); (use to make timer look good)
        // currentTimeText.text = time.ToString(@"mm\:ss\:fff") (or this one, its even better)
        currentTimeText.text = currentTime.ToString();
    }

    public void startTimer ()
    {
        timerActive = true;
    }

    public void stopTimer ()
    {
        timerActive = false;
    }

}
