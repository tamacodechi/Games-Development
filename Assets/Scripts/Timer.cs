using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 120;
    private bool timerIsRunning = true;    

    void Start()
    {
        timeRemaining = 120;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        string timerTextString = string.Format("{0:00}:{1:00}", minutes, seconds);

        GameSessionManager.gameSession.SetTimerText(timerTextString);
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public bool GetTimerRunningState()
    {
        return timerIsRunning;
    }    
    public void setTimeRemaining()
    {
        timeRemaining = 120;
        timerIsRunning = true;
    }
    public void setTimerRunningState()
    {
        timerIsRunning = true;
    }
}
