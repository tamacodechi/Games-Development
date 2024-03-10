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
            float currentPlayerSpeed = PlayerStats.playerStatsInstance.GetPlayerSpeedMultiplier();

            PlayerStats.playerStatsInstance.SetPlayerSpeedMultiplier(currentPlayerSpeed + 0.2f);

            PlayerStats.playerStatsInstance.SetSpeedLevel(PlayerStats.playerStatsInstance.GetSpeedLevel() + 1);

            speedUpgradeLevelText.text = "Lv" + PlayerStats.playerStatsInstance.GetSpeedLevel().ToString();
        }
    }

    public void UpgradeScoreMultiplier() {
        if (AttemptUpgrade(scoreMultiplierUpgradeCost)) {
            float currentScoreMultiplier = PlayerStats.playerStatsInstance.GetPlayerScoreMultiplier();

            PlayerStats.playerStatsInstance.SetPlayerScoreMultiplier(currentScoreMultiplier + 1f);

            PlayerStats.playerStatsInstance.SetScoreMultiplierLevel(PlayerStats.playerStatsInstance.GetScoreMultiplierLevel() + 1);

            scoreMultiplierLevelText.text = "Lv" + PlayerStats.playerStatsInstance.GetScoreMultiplierLevel().ToString();
        }
    }

    bool AttemptUpgrade(int cost) {
        if(PlayerStats.playerStatsInstance.GetPlayerPickupsCollected() >= cost) {
            PlayerStats.playerStatsInstance.SetPickupsCollected(PlayerStats.playerStatsInstance.GetPlayerPickupsCollected() - cost);

            RefreshCurrency();

            return true;
        }

        return false;
    }

    void RefreshCurrency() {
        currencyText.text = "Currency: " + PlayerStats.playerStatsInstance.GetPlayerPickupsCollected().ToString();
        GameSessionManager.gameSessionManagerInstance.SetPickupsCollectedText(PlayerStats.playerStatsInstance.GetPlayerPickupsCollected().ToString());
    }

    void OnEnable()
    {
        /*PlayerStats.playerStatsInstance = PlayerStats.PlayerStats.playerStatsInstanceInstance;*/

        speedUpgradeLevelText.text = "Lv" + PlayerStats.playerStatsInstance.GetSpeedLevel().ToString();
        scoreMultiplierLevelText.text = "Lv" + PlayerStats.playerStatsInstance.GetScoreMultiplierLevel().ToString();

        speedUpgradeCostText.text = "COST: " + speedUpgradeCost.ToString();
        scoreMultiplierCostText.text = "COST: " + scoreMultiplierUpgradeCost.ToString();

        RefreshCurrency();
    }
}
