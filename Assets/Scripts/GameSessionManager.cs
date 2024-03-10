using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Adding skeleton for GameSessionManager to test score increase
 */

public class GameSessionManager : MonoBehaviour
{
    public static GameSessionManager gameSession { get; private set; }

    [SerializeField] Text roundTimerText;
    [SerializeField] Text scoreText;
    [SerializeField] Text pickupsCollectedText;
    [SerializeField] GameObject tutorialObject;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject roundOverUI;
    [SerializeField] GameObject pauseMenuUI;

    public static GameSessionManager gameSessionManagerInstance;
    public Timer timer;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("HasPlayedTutorial", 0);
        if (gameSessionManagerInstance == null)
        {
            gameSessionManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);

            gameSession = this;
        } else
        {
            Destroy(this.gameObject);
        }

        
    }

    private void Start()
    {

    }

    public void SetScoreText(string newScoreText)
    {
        scoreText.text = newScoreText;
    }

    public void SetPickupsCollectedText(string newPickupsCollectedText)
    {
        pickupsCollectedText.text = newPickupsCollectedText;
    }

    public void SetTimerText(string newTimerText)
    {
        roundTimerText.text = newTimerText;
    }
    public void TogglePlayerUIActive()
    {
        playerUI.SetActive(!playerUI.activeSelf);
    }

    public void ToggleRoundOverUIActive(bool desiredState)
    {
        roundOverUI.SetActive(desiredState);
    }

    public void initializeMenuGameState()
    {
        timer.setTimeRemaining();
        timer.setTimerRunningState();
        roundOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void initializeRoundRestart()
    {
        timer.setTimeRemaining();
        timer.setTimerRunningState();
        roundOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void toggleTutorial()
    {
        if (PlayerPrefs.GetInt("HasPlayedTutorial") == 0)
        {
            tutorialObject.SetActive(true);
            PlayerPrefs.SetInt("HasPlayedTutorial", 1);
        }
        else
        {
            Time.timeScale = 1;
        }
        return;
    }
}
