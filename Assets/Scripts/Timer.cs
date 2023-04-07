using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour {

    bool timerActive = false;

    float currentTime;

    [Tooltip("Displays as seconds")]
    public int startMinutes;

    public TextMeshProUGUI currentTimeText;

    void Start()
    {
        currentTime = startMinutes * 60; // stores current time as seconds
        startTimer(); // starts as soon as the game begins (maybe change later?)
    }

    void Update()
    {
        if (timerActive == true) // checks if timer is active
        {
            currentTime = currentTime - Time.deltaTime; // decreases time by how many miliseconds since last update
            if (currentTime <= 0) // activates once timer ends
            {
                timerActive = false;
                currentTimeText.text = "0";
                Debug.Log("Timer ended");
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
