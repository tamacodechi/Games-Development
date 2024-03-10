using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    bool runOnce;
    public AudioManager AudioManager;
    /*public GameSessionManager AudioManager;*/
    // Start is called before the first frame update
    void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        Time.timeScale = 1;

        if(PlayerPrefs.GetInt("HasPlayedTutorial") == 1) return;

        PlayerPrefs.SetInt("HasPlayedTutorial", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (runOnce == false)
        {
            Button backButton = GameObject.Find("Play Button").GetComponent<Button>();

            backButton.Select();

            runOnce = true;
        }
    }

    void OnEnable()
    {
        runOnce = false;
    }

    public void StartGame() {
        SceneManager.LoadScene("allWorld");
        AudioManager.loadAudioClips();
        AudioManager.StartIdleMotorSound();
        AudioManager.PlayMusic("BackgroundCity");
        GameSessionManager.gameSessionManagerInstance.TogglePlayerUIActive();
        GameSessionManager.gameSessionManagerInstance.timer.setTimeRemaining();

    }

    public void ExitGame() {
        Application.Quit();
    }
}
