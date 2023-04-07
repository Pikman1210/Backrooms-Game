using UnityEngine;
using System;
using TMPro;

public class Stopwatch : MonoBehaviour {

    bool timerActive = false;

    float currentTime;

    public TextMeshProUGUI currentTimeText;

    void Start()
    {
        currentTime = 0; 
    }

    void Update()
    {
        if (timerActive == true) // checks if timer is active
        {
            currentTime = currentTime + Time.deltaTime; // icnreases time by how many miliseconds since last update
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        // currentTimeText.text = time.ToString(@"mm\:ss\:fff") (use to make timer look good)
        currentTimeText.text = currentTime.ToString();
    }

    public void startStopwatch ()
    {
        timerActive = true;
    }

    public void stopStopwatch ()
    {
        timerActive = false;
    }

}