using UnityEngine;

public class MaxAmmoPerk : UpgradePerk
{
    public int MaxPerkAmmoAmount = 3;
    public override void EnablePerk()
    {
        if(IsPerkOwned || CanBePurchased)
        {
            if (!IsPerkActive)
            {
                PlayerAmmoController.Instance.MaxAmmoAmount += MaxPerkAmmoAmount;
                PlayerAmmoController.Instance.AmmoAmount += MaxPerkAmmoAmount;
                PlayerAmmoController.Instance.PlayerInfoRef.UpdatePlayersStats();
                PerksController.Instance.AddPerkToList(this.gameObject);
            }
        }
    }


    public override void DisablePerk()
    {
        if(IsPerkActive)
        {
            PlayerAmmoController.Instance.MaxAmmoAmount -= MaxPerkAmmoAmount;
            PlayerAmmoController.Instance.AmmoAmount -= MaxPerkAmmoAmount;
            Debug.Log("remove max ammo perk");
        }
    }
}
