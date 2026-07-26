using UnityEngine;

public class BossSoulPickUp : BasePickUp
{
    public PlayerInfo PlayerInfoRef;
    public void PickUpBossSoul()
    {
        SoulsBankController.Instance.PayoutBossSoulToPlayer();
        PlayerInfoRef.UpdatePlayersStats();
    }
}
