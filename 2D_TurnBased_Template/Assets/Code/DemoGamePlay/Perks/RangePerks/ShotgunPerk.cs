using UnityEngine;

public class ShotgunPerk : UpgradePerk
{
    public PlayerRangeWeapon PlayerRangeWeaponRef;
    public override void EnablePerk()
    {
        PlayerRangeWeaponRef.IsUsingShotgunPerk = true;
        PlayerRangeWeaponRef.ChangeArrowsDurations();
        PerksController.Instance.AddPerkToList(this.gameObject);
    }
}
