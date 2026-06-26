using UnityEngine;

public class HealthUpgradeScript : LevelUpStat
{
    [Header("Scripts")]
    public PlayerInfo PlayerInfoRef;

    public override void UpgradeStat()
    {
        if(PlayerInfoRef.Souls >= CostAmount)
        {
            PlayerInfoRef.CharacterMaxHealth += IncrementingStatsAmount;
            PlayerInfoRef.HealthBarUIRef.SetMaxHealth(PlayerInfoRef.CharacterMaxHealth);
            PlayerInfoRef.SetHealth(PlayerInfoRef.CharacterHealthAmount);
            PlayerInfoRef.Souls -= (int)CostAmount;// if theres issues with souls being subtracted by cost amount its here.
            PlayerInfoRef.UpdatePlayersStats();
            UpdateStatsUI();
        }
        else
        {
            Debug.Log("player does not have enough souls.");
        }
        
    }
}
