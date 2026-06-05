using TMPro;
using UnityEngine;

public class UpgradePerk : MonoBehaviour
{
    public TextMeshPro PerkLvlText, CostAmountText, PerkEXPText;
    public float PerkLvl, IncrementMultipler, CostAmount, PerkEXP;

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
}
