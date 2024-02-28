using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* Adding skeleton for GameSessionManager to test score increase
 */ 

public class GameSessionManager : MonoBehaviour
{
    public static GameSessionManager gameSession { get; private set; }

    [SerializeField] TextMeshProUGUI roundTimerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI pickupsCollectedText;

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
        }
    }

    public void SetScoreText(string newScoreText)
    {
        scoreText.text = ("Score: " + newScoreText);
    }

    public void SetPickupsCollectedText(string newPickupsCollectedText)
    {
        pickupsCollectedText.text = ("Pickups Collected: " + newPickupsCollectedText);
    }

    public void SetTimerText(string newTimerText)
    {
        roundTimerText.text = ("Time Remaining: " + newTimerText);
    }
}
