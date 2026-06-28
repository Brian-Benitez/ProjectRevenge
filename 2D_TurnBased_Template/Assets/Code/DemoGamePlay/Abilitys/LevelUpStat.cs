using TMPro;
using UnityEngine;

public class LevelUpStat : MonoBehaviour
{
    public TextMeshProUGUI StatsLvlText, CostAmountText;
    public float IncrementingStatsAmount, CostAmount,  MinCostAmount, PriceMultipler;//We still need to do the rest of the abilities. Only done health.
    public int StatsLvl;

    private void Start()
    {
        MinCostAmount = CostAmount;
    }

    public void UpdateStatsUI()
    {
        CostAmount += CostAmount * PriceMultipler;
        StatsLvl++;
        StatsLvlText.text = "Lvl: " + StatsLvl;
        CostAmountText.text = " " + CostAmount;
    }
    
    public virtual void UpgradeStat()
    {
        //upgrade it how you see fit.
    }

    public virtual void RestartStat()
    {
        StatsLvl = 0;
        PriceMultipler = 1;
        CostAmount = MinCostAmount;
        UpdateStatsUI();
    }
}
