using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePerk : MonoBehaviour
{
    public TextMeshPro PerkLvlText, CostAmountText, PerkEXPText;
    public float PerkLvl, IncrementMultipler, CostAmount, PerkEXP;
    public Image PerkImage;

    public bool IsPerkActive = false;
    public bool CanBePurchased = false;
    public bool IsPerkOwned = false;
    public void UpdateUI()
    {
        PerkLvl++;
        CostAmount = IncrementMultipler * CostAmount;
        PerkLvlText.text = "Lvl: " + PerkLvl;
        CostAmountText.text = " " + CostAmount;

    }

    public virtual void EnablePerk()
    {
        //do magic
    }


    public virtual void DisablePerk()
    {
        //disable perk stuff here.
    }

    public void TryPurchasingPerk()
    {
        if (CostAmount >= SoulsBankController.instance.DemonBossSoulsBank)
        {
            CanBePurchased = true;
            IsPerkOwned = true;
        }
        else
        {
            Debug.Log("cannot purchase perk.");
            CanBePurchased = false;
        }
    }
}
