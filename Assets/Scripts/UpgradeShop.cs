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

            playerStats.SetPlayerSpeedMultiplier(currentPlayerSpeed + 0.2f);

            playerStats.SetSpeedLevel(playerStats.GetSpeedLevel() + 1);

            speedUpgradeLevelText.text = "Lv" + playerStats.GetSpeedLevel().ToString();
        }
    }

    public void UpgradeScoreMultiplier() {
        if (AttemptUpgrade(scoreMultiplierUpgradeCost)) {
            float currentScoreMultiplier = playerStats.GetPlayerScoreMultiplier();

            playerStats.SetPlayerScoreMultiplier(currentScoreMultiplier + 1f);

            playerStats.SetScoreMultiplierLevel(playerStats.GetScoreMultiplierLevel() + 1);

            scoreMultiplierLevelText.text = "Lv" + playerStats.GetScoreMultiplierLevel().ToString();
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

        speedUpgradeLevelText.text = "Lv" + playerStats.GetSpeedLevel().ToString();
        scoreMultiplierLevelText.text = "Lv" + playerStats.GetScoreMultiplierLevel().ToString();

        speedUpgradeCostText.text = "COST: " + speedUpgradeCost.ToString();
        scoreMultiplierCostText.text = "COST: " + scoreMultiplierUpgradeCost.ToString();

        RefreshCurrency();
    }
}
