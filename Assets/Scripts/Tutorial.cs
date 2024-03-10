using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    PauseMenu pauseMenuScript;

    void OnEnable()
    {
        pauseMenuScript = FindObjectOfType<PauseMenu>();
        pauseMenuScript.canPause = false;

        Time.timeScale = 0;
    }

    void OnDisable()
    {
        pauseMenuScript.canPause = true;

        Time.timeScale = 1;
    }
}
