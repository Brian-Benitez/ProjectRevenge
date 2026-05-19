using TMPro;
using UnityEngine;

public class LevelUpAblility : MonoBehaviour
{
    public TextMeshProUGUI AbilityLvlText, CostAmountText;
    public float IncrementingAbilityAmount, CostAmount, PriceMultipler;
    public int AbilityLvl;

    public void UpdateAbilityUI()
    {
        CostAmount += CostAmount * PriceMultipler;
        AbilityLvl++;
        AbilityLvlText.text = "Lvl: " + AbilityLvl;
        CostAmountText.text = " " + CostAmount;
    }
    
    public virtual void UpgradeAbility()
    {
        //upgrade it how you see fit.
    }
}
