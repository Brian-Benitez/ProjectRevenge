using UnityEngine;

public class MeleeUpgradeStat : LevelUpStat
{
    public PlayerMeleeAttack PlayerMeleeAttackRef;
    public PlayerInfo PlayerInfoRef;
    public override void UpgradeStat()
    {
        if (PlayerInfoRef.Souls >= CostAmount)
        {
            Debug.Log("upgraded melee");
            PlayerMeleeAttackRef.PlayerLightAttkDamg += IncrementingStatsAmount;
            PlayerMeleeAttackRef.PlayerHeavyAttkDamg += IncrementingStatsAmount;
            PlayerMeleeAttackRef.PlayerSpecialDamg += IncrementingStatsAmount;
            StatsLvl++;
            PlayerInfoRef.Souls -= (int)CostAmount;
            PlayerInfoRef.UpdatePlayersStats();
        }
    }
}
