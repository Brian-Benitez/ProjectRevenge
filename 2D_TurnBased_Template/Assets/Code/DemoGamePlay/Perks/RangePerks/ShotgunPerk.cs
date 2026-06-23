using UnityEngine;

public class ShotgunPerk : UpgradePerk
{
    public PlayerRangeWeapon PlayerRangeWeaponRef;
    public override void EnablePerk()
    {
        if(IsPerkOwned || CanBePurchased)
        {
            if (!IsPerkActive)
            {
                PlayerRangeWeaponRef.IsUsingShotgunPerk = true;
                PlayerRangeWeaponRef.ChangeArrowsDurations();
                PerksController.Instance.AddPerkToList(this.gameObject);
            }
        }   
    }

    public override void DisablePerk()
    {
        PlayerRangeWeaponRef.NormalArrowDurations();
    }
}
