using TMPro;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [Header("Upgrade Amounts")]
    public int HealthUpgradeAmount;

    [Header("Cost per Upgrade")]
    public int CostAmountForHealthUpgrade;

    [Header("Level of Upgrades")]
    public int HealthLevelUpgrade;

    [Header("Texts")]
    public TextMeshProUGUI HealthCostAmountText;
    public TextMeshProUGUI HealthLevelAmountText;

    private PlayerInfo _playerInfo;

    private void Start()
    {
        _playerInfo = GetComponent<PlayerInfo>();
    }

    public void UpgradePlayerHealth()//used OnClick for UI.
    {
        if(_playerInfo.Souls >= CostAmountForHealthUpgrade)
        {
            Debug.Log("upgraded health + " + HealthUpgradeAmount);
            _playerInfo.CharacterMaxHealthLevel += HealthUpgradeAmount;
            _playerInfo.UpdatePlayersStats();
            _playerInfo.Souls -= CostAmountForHealthUpgrade;
            UpdateUIForUpgradeMenu();
        }
        else
        {
            Debug.Log("Player does not have enough souls.");
        }
    }

    public void UpdateUIForUpgradeMenu()
    {
        HealthCostAmountText.text = " " + CostAmountForHealthUpgrade * 2;
        HealthLevelUpgrade += 1;
        HealthLevelAmountText.text = " " + HealthLevelUpgrade;
    }
}
