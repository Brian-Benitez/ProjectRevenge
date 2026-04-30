using UnityEngine;

public class HealthPickUp : BasePickUp
{
    [Header("Health Info")]
    public float HealthGain;

    public void HealPlayer()
    {
        HealingPlayerController.Instance.PlayerInfoRef.SetHealth(HealthGain);
        HealingPlayerController.Instance.PlayerInfoRef.UpdatePlayersStats();
    }
}
