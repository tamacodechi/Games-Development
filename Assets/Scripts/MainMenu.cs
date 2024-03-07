using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    bool runOnce;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void ExitGame() {
        Application.Quit();
    }
}
