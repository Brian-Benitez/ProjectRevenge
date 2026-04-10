using UnityEngine;

public class PerksController : MonoBehaviour
{
    public static PerksController Instance;
    [Header("Rage Perks Settings")]
    public GameObject RagePerksOptionsGo;
  
    [Header("Range Perks Settings")]
    public RangePerks RangePerksRef;
    public GameObject RangePerksOptionsGO;

    [Header("Speical Perk Settings")]
    public SpeicalPerk SpeicalPerkRef;
    public GameObject SpeicalPerkOptionsGO;

    [Header("UIs")]
    public GameObject PerksUIGO;
    public GameObject LevelUpUIGO;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void EnablePerksUI()
    {
        LevelUpUIGO.SetActive(false);
        PerksUIGO.SetActive(true);
    }
    public void DisablePerksUI()
    {
        LevelUpUIGO.SetActive(true); 
        PerksUIGO.SetActive(false);
    }
    public void EnableRagePerkOptions() => RagePerksOptionsGo.SetActive(true);

    public void EnableRangePerkOptions() => RangePerksOptionsGO.SetActive(true);

    public void EnableSpeicalPerkOptions() => SpeicalPerkOptionsGO.SetActive(true);
    public void DisableAllGOs()
    {
        RagePerksOptionsGo.SetActive(false);
        RangePerksOptionsGO.SetActive(false);
        SpeicalPerkOptionsGO.SetActive(false);
    }
}
