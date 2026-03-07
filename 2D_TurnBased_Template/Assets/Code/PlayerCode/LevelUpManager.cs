using TMPro;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [Header("Upgrade imcrements")]
    public int HealthUpgradeImcrement;
    public int RangeUpgradeImcrement;
    public int RageUpgradeIncrement;
    public float MeleeUpgradeIncrement;

    [Header("Cost per Upgrade")]
    public int CostForHealthUpgrade;
    public int CostForRangeUpgrade;
    public int CostForDashUpgrade;
    public int CostyForMeleeUpgrade;
    public int CostForRageUpgrade;

    [Header("Level of Upgrades")]
    public int HealthLevelUpgrade;
    public int RangeLevelUpgrade;

    [Header("Texts")]
    public TextMeshProUGUI HealthCostAmountText;
    public TextMeshProUGUI HealthLevelAmountText;
    public TextMeshProUGUI MeleeCostAmountText;
    public TextMeshProUGUI RageCostAmountText;
    public TextMeshProUGUI DashCostAmountText;

    public TextMeshProUGUI RangeCostAmountText;
    public TextMeshProUGUI RangeLevelAmountText;

    public bool UpgradedHealth = false;
    public bool UpgradedRange = false;

    public PlayerMovement PlayerMovementRef;
    public PlayerInfo _playerInfo;
    public PlayerMeleeAttack PlayerMeleeAttackRef;

    public void UpgradePlayerHealth()//used OnClick for UI.
    {
        if(_playerInfo.Souls >= CostForHealthUpgrade)
        {
            Debug.Log("upgraded health + " + HealthUpgradeImcrement);
            _playerInfo.CharacterMaxHealth += HealthUpgradeImcrement;
            _playerInfo.HealAllHealth();
            _playerInfo.Souls -= CostForHealthUpgrade;
            _playerInfo.UpdatePlayersStats();
            UpgradedHealth = true;
            UpdateUIForUpgradeMenu(HealthCostAmountText, CostForHealthUpgrade);
        }
        else
        {
            Debug.Log("Player does not have enough souls.");
        }
    }

    public void UpgradeMeleeDam()
    {
        if(_playerInfo.Souls >= CostyForMeleeUpgrade)
        {
            PlayerMeleeAttackRef.PlayerLightAttkDamg += MeleeUpgradeIncrement;
            PlayerMeleeAttackRef.PlayerHeavyAttkDamg += MeleeUpgradeIncrement;
            PlayerMeleeAttackRef.PlayerSpecialDamg += MeleeUpgradeIncrement;
            _playerInfo.Souls -= CostyForMeleeUpgrade;
            _playerInfo.UpdatePlayersStats();
            UpdateUIForUpgradeMenu(MeleeCostAmountText, CostyForMeleeUpgrade);
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
            UpdateUIForUpgradeMenu(RangeCostAmountText, CostForRangeUpgrade);
        }
    }

    public void UpgradeRage()
    {
        if(_playerInfo.Souls >= CostForRageUpgrade)
        {
            Debug.Log("upgraded rage");
            _playerInfo.Souls -= CostForRageUpgrade;
            PlayersUltController.Instance.MaxUltPoints += RageUpgradeIncrement;//gotta upgrade the ui for the upgrades
            _playerInfo.UpdatePlayersStats();
            UpdateUIForUpgradeMenu(RageCostAmountText, CostForRageUpgrade);
        }
    }
    public void UpgradeDash()
    {
        if(_playerInfo.Souls >= CostForDashUpgrade)
        {
            PlayerMovementRef.DashCoolDown -= PlayerMovementRef.DashCoolDownUpgrade;
            _playerInfo.Souls -= CostForDashUpgrade;
            _playerInfo.UpdatePlayersStats();
            UpdateUIForUpgradeMenu(DashCostAmountText, CostForDashUpgrade);
        }
    }
    public void UpdateUIForUpgradeMenu(TextMeshProUGUI costText, int costAmount)
    {
        costText.text = " " + costAmount * 2;    
    }
}
