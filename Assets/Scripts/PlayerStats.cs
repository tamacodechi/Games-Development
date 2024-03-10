using UnityEngine;

//Script manages the player stats we want to track
public class PlayerStats : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int pickupsCollected = 0;
    [SerializeField] float playerSpeedMultiplier = 1f;
    [SerializeField] float playerScoreMultiplier = 1f;
    [SerializeField] int speedLevel = 1;
    [SerializeField] int scoreMultiplierLevel = 1;

    public static PlayerStats playerStatsInstance;

    // Start is called before the first frame update
    void Awake()
    {
        if (playerStatsInstance == null)
        {
            playerStatsInstance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);
    }
    void Start()
    {
        GameSessionManager.gameSession.SetScoreText(score.ToString());
        GameSessionManager.gameSession.SetPickupsCollectedText(pickupsCollected.ToString());
    }

    public void AddToScore(int scoreValue)
    {
        int currentScore = score;
        score = currentScore + Mathf.RoundToInt(scoreValue * playerScoreMultiplier);
        GameSessionManager.gameSession.SetScoreText(score.ToString());
    }

    public void AddToPickupsCollected()
    {
        pickupsCollected++;
        GameSessionManager.gameSession.SetPickupsCollectedText(pickupsCollected.ToString());
    }

    public void SetPlayerSpeedMultiplier(float newSpeedMultiplier)
    {
        playerSpeedMultiplier = newSpeedMultiplier;
    }
    public float GetPlayerSpeedMultiplier()
    {
        return playerSpeedMultiplier;
    }

    public void SetPlayerScoreMultiplier(float newScoreMultiplier)
    {
        playerScoreMultiplier = newScoreMultiplier;
    }
    public float GetPlayerScoreMultiplier()
    {
        return playerScoreMultiplier;
    }

    public int GetPlayerPickupsCollected()
    {
        return pickupsCollected;
    }
    public void SetPickupsCollected(int newPickupsCollected) {
        pickupsCollected = newPickupsCollected;
    }

    public int GetSpeedLevel() {
        return speedLevel;
    }
    public void SetSpeedLevel(int newSpeedLevel) {
        speedLevel = newSpeedLevel;
    }

    public int GetScoreMultiplierLevel() {
        return scoreMultiplierLevel;
    }
    public void SetScoreMultiplierLevel(int newScoreMultiplierLevel) {
        scoreMultiplierLevel = newScoreMultiplierLevel;
    }


}
