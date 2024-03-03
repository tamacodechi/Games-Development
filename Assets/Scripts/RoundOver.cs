﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundOver : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject roundOverUI;
    PauseMenu pauseMenuScript;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuScript = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        /*        GameObject timerObject = GameObject.Find("Timer");
                timerObjectScript = timerObject.GetComponent<Timer> ();*/
        if (!timer.GetTimerRunningState())
        {
            EndRound();
        }
    }


    void EndRound()
    {
        pauseMenuScript.canPause = false;
        Time.timeScale = 0;
        roundOverUI.SetActive(true);
    }

    public void PlayNextRound()
    {
        SceneManager.LoadScene("allWorld");
    }
}
