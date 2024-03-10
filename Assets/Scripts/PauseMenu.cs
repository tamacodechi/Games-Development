using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI = null;
    bool isPaused;
    public bool canPause = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (!canPause) return;

        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenuUI.SetActive(isPaused);
    }

    public void ExitToMainMenu()
    {
        GameSessionManager.gameSessionManagerInstance.initializeMenuGameState();
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickHandler()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenuUI.SetActive(false);
    }
    public void SetCanPause(bool desiredState)
    {
        canPause = desiredState;
    }

}
