using UnityEngine;

public class TypeOfKillScore : MonoBehaviour
{
    public static TypeOfKillScore Instance;// pausing this for now.. Need to know how I can do this better or if I want to do this.
    [Header("Range Perks counters")]
    public int MaxAmmoKillCounter, ShotgunKillCounter;

    public RangePerks RangePerksRef;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void HowDidEnemyDie()
    {
        if(RangePerksRef.IsRangePerkEquipped)
        {
            if (RangePerksRef.IsUsingMaxAmmoPerk)
                MaxAmmoKillCounter++;
            else if (RangePerksRef.IsUsingShotgunPerk)
                ShotgunKillCounter++;
        }
    }
}
