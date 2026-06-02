using UnityEngine;

public class RangePerks : MonoBehaviour
{
    [Header("Increase Max Ammo Perk Settings")]
    public int MaxPerkAmmoAmount;
    public bool IsUsingMaxAmmoPerk = false;
    public bool IsUsingShotgunPerk = false;
    public bool IsRangePerkEquipped = false;

    public PlayerRangeWeapon PlayerRangeWeaponRef;
   
    public void ActivateRangePerk()
    {
        if (!IsRangePerkEquipped)
        {
            if (IsUsingMaxAmmoPerk)
                MaxAmmoPerk();
            if (IsUsingShotgunPerk)
                ShotgunPerk();
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
            PlayerAmmoController.Instance.MaxAmmoAmount -= MaxPerkAmmoAmount;
            PlayerAmmoController.Instance.AmmoAmount -= MaxPerkAmmoAmount;
            if (PlayerAmmoController.Instance.MaxAmmoAmount < 0 )
            {
                PlayerAmmoController.Instance.AmmoAmount = 0;
            }
        }
        if (IsUsingShotgunPerk)
            PlayerRangeWeaponRef.NormalArrowDurations();
    }

    public void MaxAmmoPerk()
    {
        PlayerAmmoController.Instance.MaxAmmoAmount += MaxPerkAmmoAmount;
        PlayerAmmoController.Instance.AmmoAmount += MaxPerkAmmoAmount;
        PlayerAmmoController.Instance.PlayerInfoRef.UpdatePlayersStats();
        Debug.Log("max ammo perk is enabled");
    }

    public void ShotgunPerk()
    {
        PlayerRangeWeaponRef.IsUsingShotgunPerk = true;
        PlayerRangeWeaponRef.ChangeArrowsDurations();
        Debug.Log("is using shotgun perk");
    }

    public void RestartAllPerks()
    {
        IsUsingShotgunPerk = false;
        IsUsingMaxAmmoPerk = false;
        IsRangePerkEquipped = false;
    }

    public void SetMaxAmmoPerk()
    {
        IsUsingMaxAmmoPerk = true;
        IsUsingShotgunPerk = false;
    }
    public void SetShotgunPerk()
    {
        IsUsingShotgunPerk = true;
        IsUsingMaxAmmoPerk = false;
    }
}
