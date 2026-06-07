using UnityEngine;

public class MaxAmmoPerk : UpgradePerk
{
    public int MaxPerkAmmoAmount = 3;
    public override void EnablePerk()
    {
        if(!IsPerkActive)
        {
            PlayerAmmoController.Instance.MaxAmmoAmount += MaxPerkAmmoAmount;
            PlayerAmmoController.Instance.AmmoAmount += MaxPerkAmmoAmount;
            PlayerAmmoController.Instance.PlayerInfoRef.UpdatePlayersStats();
            PerksController.Instance.AddPerkToList(this.gameObject);
        }
    }


    public override void DisablePerk()
    {
        PlayerAmmoController.Instance.MaxAmmoAmount -= MaxPerkAmmoAmount; //Mathf.Clamp(MaxPerkAmmoAmount, 5, 8);
        //PlayerAmmoController.Instance.MaxAmmoAmount = Mathf.Clamp(MaxPerkAmmoAmount, 5, 8);
        PlayerAmmoController.Instance.AmmoAmount -= MaxPerkAmmoAmount;//Mathf.Clamp(MaxPerkAmmoAmount, 0, PlayerAmmoController.Instance.MaxAmmoAmount);
        //PlayerAmmoController.Instance.AmmoAmount = Mathf.Clamp(MaxPerkAmmoAmount, 0, PlayerAmmoController.Instance.MaxAmmoAmount);
        Debug.Log("remove max ammo perk");
    }
}
