using UnityEngine;

public class PerksController : MonoBehaviour
{
    public static PerksController Instance;
    public int ActivePerksCount;
    public int MaxCountOfPerks;
    [Header("UIs")]
    public GameObject AllPerksUI;
    public GameObject PerksUIGO;
    public GameObject LevelUpUIGO;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void CheckOnPerksCount()
    {
        if (MaxCountOfPerks == ActivePerksCount)
            Debug.Log("Max amount of perks active, remove one.");
        else
            Debug.Log("added a perk");
    }

    public void EnableAllPerksMenu() => AllPerksUI.SetActive(true);
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
   
    public void DisableAllGOs()
    {
       AllPerksUI.SetActive(false); 
    }
}
