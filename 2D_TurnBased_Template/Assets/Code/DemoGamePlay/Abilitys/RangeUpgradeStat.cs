using UnityEngine;

public class RangeUpgradeStat : LevelUpStat
{
    public PlayerInfo PlayerInfoRef;
    public override void UpgradeStat()
    {
        if (PlayerInfoRef.Souls >= CostAmount)
        {
            PlayerInfoRef.RangeDamg += IncrementingStatsAmount;
            StatsLvl++;
            PlayerInfoRef.Souls -= (int)CostAmount;
            PlayerInfoRef.UpdatePlayersStats();
        }
    }
}
