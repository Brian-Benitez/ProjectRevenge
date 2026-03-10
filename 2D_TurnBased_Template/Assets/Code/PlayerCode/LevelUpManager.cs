using TMPro;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [Header("Upgrade imcrements")]
    public float HealthUpgradeImcrement;
    public float RangeUpgradeImcrement;
    public float RageUpgradeIncrement;
    public float MeleeUpgradeIncrement;

    [Header("Cost per Upgrade")]
    public int CostForHealthUpgrade;
    public int CostForRangeUpgrade;
    public int CostForDashUpgrade;
    public int CostyForMeleeUpgrade;
    public int CostForRageUpgrade;

    [Header("Texts")]
    public TextMeshProUGUI HealthCostAmountText;
    public TextMeshProUGUI MeleeCostAmountText;
    public TextMeshProUGUI RageCostAmountText;
    public TextMeshProUGUI DashCostAmountText;

    public TextMeshProUGUI RangeCostAmountText;

    [Header("Percentage Text")]
    public TextMeshProUGUI HealthPercentText;
    public TextMeshProUGUI MeleePercentText;
    public TextMeshProUGUI RagePercentText;
    public TextMeshProUGUI DashPercentText;
    public TextMeshProUGUI RangePercentText;

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
            UpdateUIForUpgradeMenu(HealthCostAmountText, HealthPercentText, CostForHealthUpgrade, HealthUpgradeImcrement);
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
            Debug.Log("upgraded melee");
            PlayerMeleeAttackRef.PlayerLightAttkDamg += MeleeUpgradeIncrement;
            PlayerMeleeAttackRef.PlayerHeavyAttkDamg += MeleeUpgradeIncrement;
            PlayerMeleeAttackRef.PlayerSpecialDamg += MeleeUpgradeIncrement;
            _playerInfo.Souls -= CostyForMeleeUpgrade;
            _playerInfo.UpdatePlayersStats();
            UpdateUIForUpgradeMenu(MeleeCostAmountText, MeleePercentText, CostyForMeleeUpgrade, MeleeUpgradeIncrement);
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
            UpdateUIForUpgradeMenu(RangeCostAmountText, RangePercentText, CostForRangeUpgrade, RangeUpgradeImcrement);
        }
    }

    public void UpgradeRage()
    {
        if(_playerInfo.Souls >= CostForRageUpgrade)
        {
            Debug.Log("upgraded rage");
            _playerInfo.Souls -= CostForRageUpgrade;
            PlayersUltController.Instance.MaxUltPoints += RageUpgradeIncrement;
            _playerInfo.UpdatePlayersStats();
            UpdateUIForUpgradeMenu(RageCostAmountText, RagePercentText, CostForRageUpgrade, RageUpgradeIncrement);
        }
    }
    public void UpgradeDash()
    {
        if(_playerInfo.Souls >= CostForDashUpgrade)
        {
            PlayerMovementRef.DashCoolDown -= PlayerMovementRef.DashCoolDownUpgrade;
            _playerInfo.Souls -= CostForDashUpgrade;
            _playerInfo.UpdatePlayersStats();
            UpdateUIForUpgradeMenu(DashCostAmountText, DashPercentText, CostForDashUpgrade, PlayerMovementRef.DashCoolDownUpgrade);
        }
    }
    public void UpdateUIForUpgradeMenu(TextMeshProUGUI costText, TextMeshProUGUI percentUI, int costAmount, float upgradeIncrement)
    {
        costText.text = " " + costAmount * 1.5;
        percentUI.text = " " + upgradeIncrement + "%";
        Debug.Log("im hit");
    }
}
