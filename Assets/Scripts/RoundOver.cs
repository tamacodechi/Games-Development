using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundOver : MonoBehaviour
{
    PauseMenu pauseMenuScript;
    
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {

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
		GameObject pauseMenuObject = GameObject.Find("Pause Menu");

		pauseMenuScript = pauseMenuObject.GetComponent<PauseMenu> ();
        pauseMenuScript.canPause = false;
        Time.timeScale = 0;

        GameObject roundOverUIObject = GameObject.Find("Round Over").transform.Find( "Round Over UI" ).gameObject;
        roundOverUIObject.gameObject.SetActive(true);
    }

    public void PlayNextRound() 
    {
        SceneManager.LoadScene("allWorld");
    }
}
