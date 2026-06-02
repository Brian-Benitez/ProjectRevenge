using TMPro;
using UnityEngine;

public class UpgradePerk : MonoBehaviour
{
    public TextMeshPro PerklvlText, CostAmountText, PerkEXPText;
    public float PerkLvl, IncrementMultipler, CostAmount, PerkEXP;

    public void UpdateUI()
    {
        PerkLvl++;
        CostAmount = IncrementMultipler * CostAmount;
        PerklvlText.text = "Lvl: " + PerkLvl;
        CostAmountText.text = " " + CostAmount;

    }

    public virtual void UpgradePerkHere()
    {
        //do magic
    }

}
