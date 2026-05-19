using UnityEngine;

public class HealthUpgradeScript : LevelUpAblility
{
    [Header("Scripts")]
    public PlayerInfo PlayerInfoRef;

    public override void UpgradeAbility()
    {
        if(PlayerInfoRef.Souls >= CostAmount)
        {
            PlayerInfoRef.CharacterMaxHealth += IncrementingAbilityAmount;
            PlayerInfoRef.HealthBarUIRef.SetMaxHealth(PlayerInfoRef.CharacterMaxHealth);
            PlayerInfoRef.SetHealth(PlayerInfoRef.CharacterHealthAmount);
            PlayerInfoRef.Souls -= (int)CostAmount;// if theres issues with souls being subtracted by cost amount its here.
            PlayerInfoRef.UpdatePlayersStats();
            UpdateAbilityUI();
        }
        else
        {
            Debug.Log("player does not have enough souls.");
        }
        
    }
}
