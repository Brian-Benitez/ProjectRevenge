using UnityEngine;

public class RageUpgradeStat : LevelUpStat
{
    public PlayerInfo PlayerInfoRef;
    public override void UpgradeStat()
    {
        if (PlayerInfoRef.Souls >= CostAmount)
        {
            Debug.Log("upgraded rage");
            PlayerInfoRef.Souls -= (int)CostAmount;
            StatsLvl++;
            PlayersUltController.Instance.MaxUltPoints += IncrementingStatsAmount;
            PlayerInfoRef.UpdatePlayersStats();
        }
    }
}
