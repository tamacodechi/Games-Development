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

    PlayerStats playerStats;

    private void Awake()
    {
        if (gameSession != null && gameSession != this)
        {
            Destroy(this);
        }
        else
        {
            gameSession = this;

            if (PlayerPrefs.GetInt ("HasPlayedTutorial") == 0) {
                tutorialObject.SetActive(true);
                PlayerPrefs.SetInt("HasPlayedTutorial", 1);
            } else {
                Time.timeScale = 1;
            }
        }
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
}
