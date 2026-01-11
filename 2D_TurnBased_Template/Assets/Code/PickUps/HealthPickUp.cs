using UnityEngine;

public class HealthPickUp : BasePickUp
{
    [Header("Health Info")]
    public int HealthGain;

    public PlayerInfo PlayerInfoRef;

    //All pick up functions below
    public void HealPlayer()
    {
        PlayerController.Instance.Player.GetComponent<BaseCharacter>().CharacterHealthAmount += HealthGain;
        PlayerInfoRef.UpdatePlayersStats();
    }
}
