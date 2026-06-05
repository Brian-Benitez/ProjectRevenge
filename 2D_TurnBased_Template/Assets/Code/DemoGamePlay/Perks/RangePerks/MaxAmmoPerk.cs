using UnityEngine;

public class MaxAmmoPerk : UpgradePerk
{
    public int MaxPerkAmmoAmount = 3;
    public override void EnablePerk()
    {
        PlayerAmmoController.Instance.MaxAmmoAmount += MaxPerkAmmoAmount;
        PlayerAmmoController.Instance.AmmoAmount += MaxPerkAmmoAmount;
        PlayerAmmoController.Instance.PlayerInfoRef.UpdatePlayersStats();
        PerksController.Instance.AddPerkToList(this.gameObject);
    }
    
}
