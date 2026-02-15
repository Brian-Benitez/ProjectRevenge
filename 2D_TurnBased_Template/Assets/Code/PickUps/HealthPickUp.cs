using UnityEngine;

public class HealthPickUp : BasePickUp
{
    [Header("Health Info")]
    public int HealthGain;

    public PlayerInfo PlayerInfoRef;

    //All pick up functions below
    public void HealPlayer()
    {
        PlayerInfoRef.CharacterHealthAmount += HealthGain;

        if(PlayerInfoRef.CharacterHealthAmount > PlayerInfoRef.CharacterMaxHealth)
        {
            PlayerInfoRef.CharacterHealthAmount = PlayerInfoRef.CharacterMaxHealth;
        }
        PlayerInfoRef.UpdatePlayersStats();
    }
}
