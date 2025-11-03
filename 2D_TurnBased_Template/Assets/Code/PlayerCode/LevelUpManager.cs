using TMPro;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [Header("Upgrade imcrements")]
    public int HealthUpgradeImcrement;
    public int RangeUpgradeImcrement;

    [Header("Cost per Upgrade")]
    public int CostForHealthUpgrade;
    public int CostForRangeUpgrade;

    [Header("Level of Upgrades")]
    public int HealthLevelUpgrade;
    public int RangeLevelUpgrade;

    [Header("Texts")]
    public TextMeshProUGUI HealthCostAmountText;
    public TextMeshProUGUI HealthLevelAmountText;

    public TextMeshProUGUI RangeCostAmountText;
    public TextMeshProUGUI RangeLevelAmountText;

    public bool UpgradedHealth = false;
    public bool UpgradedRange = false;

    private PlayerInfo _playerInfo;

    private void Start()
    {
        _playerInfo = GetComponent<PlayerInfo>();
    }

    public void UpgradePlayerHealth()//used OnClick for UI.
    {
        if(_playerInfo.Souls >= CostForHealthUpgrade)
        {
            Debug.Log("upgraded health + " + HealthUpgradeImcrement);
            _playerInfo.CharacterMaxHealthLevel += HealthUpgradeImcrement;
            _playerInfo.Souls -= CostForHealthUpgrade;
            _playerInfo.UpdatePlayersStats();
            UpgradedHealth = true;
            UpdateUIForUpgradeMenu();
        }
        else
        {
            Debug.Log("Player does not have enough souls.");
        }
    }

    public void UpgradeRangeDamage()//use for OnClick for UI.
    {
        if(_playerInfo.Souls >= CostForRangeUpgrade)
        {
            Debug.Log("Upgraded range damage + " +  CostForRangeUpgrade);
            _playerInfo.RangeDamg += RangeUpgradeImcrement;
            _playerInfo.Souls -= CostForRangeUpgrade;
            _playerInfo.UpdatePlayersStats();
            UpgradedRange = true;
            UpdateUIForUpgradeMenu();
        }
    }
    public void UpdateUIForUpgradeMenu()//this needs work, cannot have all of this now
    {
        if(UpgradedHealth)
        {
            //health ui updates
            HealthLevelUpgrade += 1;
            HealthCostAmountText.text = " " + CostForHealthUpgrade * 2;
            HealthLevelAmountText.text = " " + HealthLevelUpgrade;
            UpgradedHealth = false;
        }
        if(UpgradedRange)
        {
            //range ui updates
            RangeLevelUpgrade += 1;
            RangeCostAmountText.text = " " + CostForRangeUpgrade * 2;
            RangeLevelAmountText.text = " " + RangeLevelUpgrade;
            UpgradedRange = false;
        }
        
    }
}
