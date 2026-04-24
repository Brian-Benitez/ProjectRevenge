using UnityEngine;

public class RangePerks : MonoBehaviour
{
    [Header("Increase Max Ammo Perk Settings")]
    public int MaxPerkAmmoAmount;
    public bool IsUsingMaxAmmoPerk = false;
    public bool IsRangePerkEquipped = false;

    public void SetMaxAmmoPerk() => IsUsingMaxAmmoPerk = true;
    public void ActivateRangePerk()
    {
        if (!IsRangePerkEquipped)
        {
            if (IsUsingMaxAmmoPerk)
                MaxAmmoPerk();
        }
        else
        {
            Debug.Log("has a perk already");
        }
    }
    public void ResetPlayerFromRangePerk()
    {
        IsRangePerkEquipped = false;
        if(IsUsingMaxAmmoPerk)
        {
            PlayerAmmoController.Instance.MaxAmountAmount -= MaxPerkAmmoAmount;
            PlayerAmmoController.Instance.AmmoAmount -= MaxPerkAmmoAmount;
            if (PlayerAmmoController.Instance.MaxAmountAmount < 0 )
            {
                PlayerAmmoController.Instance.AmmoAmount = 0;
            }
        }
    }

    public void MaxAmmoPerk()
    {
        IsRangePerkEquipped = true;
        PlayerAmmoController.Instance.MaxAmountAmount += MaxPerkAmmoAmount;
        PlayerAmmoController.Instance.AmmoAmount += MaxPerkAmmoAmount;
        PlayerAmmoController.Instance.PlayerInfoRef.UpdatePlayersStats();
        Debug.Log("max ammo perk is enabled");
    }

    //add more perks here ----------------------------------------------------------------------->
}
