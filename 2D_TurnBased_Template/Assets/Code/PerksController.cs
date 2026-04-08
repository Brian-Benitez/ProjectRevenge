using UnityEngine;

public class PerksController : MonoBehaviour
{
    public static PerksController Instance;
    [Header("Rage Settings")]
    public GameObject RagePerksOptionsGo;

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
    public void DisableAllGOs()
    {
        RagePerksOptionsGo.SetActive(false);
    }
}
