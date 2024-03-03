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
    [SerializeField] Text speedUpgradeCostText;

    [SerializeField] Text scoreMultiplierLevelText;
    [SerializeField] Text scoreMultiplierCostText;

    [SerializeField] Text currencyText;

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
        if (AttemptUpgrade(speedUpgradeCost)) {
            float currentPlayerSpeed = playerStats.GetPlayerSpeedMultiplier();

            playerStats.SetPlayerSpeedMultiplier(currentPlayerSpeed + 0.5f);

            speedUpgradeLevel++;

            speedUpgradeLevelText.text = "Lv" + speedUpgradeLevel.ToString();
        }
    }

    public void UpgradeScoreMultiplier() {
        if (AttemptUpgrade(scoreMultiplierUpgradeCost)) {
            float currentScoreMultiplier = playerStats.GetPlayerScoreMultiplier();

            playerStats.SetPlayerScoreMultiplier(currentScoreMultiplier + 1f);

            scoreMultiplierUpgradeLevel++;

            scoreMultiplierLevelText.text = "Lv" + scoreMultiplierUpgradeLevel.ToString();
        }
    }

    bool AttemptUpgrade(int cost) {
        if(playerStats.GetPlayerPickupsCollected() >= cost) {
            playerStats.SetPickupsCollected(playerStats.GetPlayerPickupsCollected() - cost);

            RefreshCurrency();

            return true;
        }

        return false;
    }

    void RefreshCurrency() {
        currencyText.text = "Currency: " + playerStats.GetPlayerPickupsCollected().ToString();
    }

    void OnEnable()
    {
        playerStats = PlayerStats.playerStatsInstance;

        speedUpgradeLevelText.text = "Lv" + playerStats.GetPlayerSpeedMultiplier().ToString();
        scoreMultiplierLevelText.text = "Lv" + playerStats.GetPlayerScoreMultiplier().ToString();

        speedUpgradeCostText.text = "COST: " + speedUpgradeCost.ToString();
        scoreMultiplierCostText.text = "COST: " + scoreMultiplierUpgradeCost.ToString();

        RefreshCurrency();
    }
}
