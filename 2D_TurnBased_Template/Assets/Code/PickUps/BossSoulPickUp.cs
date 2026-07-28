using UnityEngine;

public class BossSoulPickUp : BasePickUp
{
    public void PickUpBossSoul()
    {
        SoulsBankController.Instance.PayoutBossSoulToPlayer();
    }
}
