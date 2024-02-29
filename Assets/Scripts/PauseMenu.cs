using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;
    bool isPaused;
    public bool canPause = false;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(isPaused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause() {
        if (!canPause) return;

        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    public void ExitToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
