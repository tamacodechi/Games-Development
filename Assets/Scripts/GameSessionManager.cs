using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* Adding skeleton for GameSessionManager to test score increase
 * 
 * 
 * 
 * 
 *
 *
 */ 

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] int score = 0;

    [SerializeField] int collectibles = 0;

    [SerializeField] float roundTimer = 120;

    [SerializeField] TextMeshProUGUI roundTimerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI collectiblesText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        collectiblesText.text = collectibles.ToString();
        roundTimerText.text = roundTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        updateTimer();
    }
    public void ProcessRoundEnd()
    {
        if(roundTimer <= 0)
        {
            //GoTo next round screen
        }
    }

    void reset()
    {
       // SceneManager.LoadScene(0);

    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = score.ToString();
        Debug.Log("Score is " + score);
    }

    public void AddCollectible(int collectibleAmount)
    {
        collectibles += collectibleAmount;
        collectiblesText.text = collectibles.ToString();
        Debug.Log("Colletible value is " + collectibles);
    }

    //Need to fix time lapse - at this time the purpose of updating the canvas is achieved.
    private void updateTimer()
    {
        float timeLapsed = Time.time;
        roundTimer = roundTimer - timeLapsed;
        roundTimerText.text = roundTimer.ToString();
    }
}
