using TMPro;
using UnityEngine;

public class LevelUpAblility : MonoBehaviour
{
    public TextMeshProUGUI AbilityLvlText, CostAmountText;
    public float IncrementingAbilityAmount, CostAmount, PriceMultipler;//We still need to do the rest of the abilities. Only done health.
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
