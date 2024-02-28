using UnityEngine;

//Script manages the player stats we want to track
public class PlayerStats : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int pickupsCollected = 0;
    [SerializeField] float playerSpeedMultiplier = 1f;
    [SerializeField] float playerScoreMultiplier = 1f;

    // Start is called before the first frame update
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
}
