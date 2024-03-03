using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] int speedUpgradeLevel;
    [SerializeField] int speedUpgradeCost;

    [SerializeField] int scoreMultiplierUpgradeLevel;
    [SerializeField] int scoreMultiplierUpgradeCost;

    [SerializeField] Text speedUpgradeLevelText;
    [SerializeField] Text scoreMultiplierLevelText;

    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeSpeed() {
        float currentPlayerSpeed = playerStats.GetPlayerSpeedMultiplier();

        playerStats.SetPlayerSpeedMultiplier(currentPlayerSpeed + 0.5f);

        speedUpgradeLevel++;

        speedUpgradeLevelText.text = speedUpgradeLevel.ToString();
    }

    public void UpgradeScoreMultiplier() {
        float currentScoreMultiplier = playerStats.GetPlayerScoreMultiplier();

        playerStats.SetPlayerScoreMultiplier(currentScoreMultiplier + 1f);

        scoreMultiplierUpgradeLevel++;

        scoreMultiplierLevelText.text = scoreMultiplierUpgradeLevel.ToString();
    }

    void OnEnable()
    {
        playerStats = PlayerStats.playerStatsInstance;

        speedUpgradeLevelText.text = playerStats.GetPlayerSpeedMultiplier().ToString();
        scoreMultiplierLevelText.text = playerStats.GetPlayerScoreMultiplier().ToString();
    }
}
