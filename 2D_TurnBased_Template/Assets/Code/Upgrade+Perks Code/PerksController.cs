using System.Collections.Generic;
using UnityEngine;
public class PerksController : MonoBehaviour
{
    public static PerksController Instance;
    public int MaxAmountOfPerks;
    public List<GameObject> ListOfActivePerks;
    public int ListIndex;
    [Header("UIs")]
    public GameObject AllPerksUI;
    public GameObject PerksUIGO;
    public GameObject LevelUpUIGO;
    [Header("everything below must be moved!")]
    [Header("Highlights")]
    public List<GameObject> Highlights;

    [Header("Archers For Images")]
    public List<GameObject> PosForImages;
    public GameObject IconsResetPOS;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void AddPerkToList(GameObject GO)
    {
        bool _isPerkInList = false;

        for (int i = 0; i < ListOfActivePerks.Count; i++)//use if(listofactiveperks.contains(GO)
        {
            if (ListOfActivePerks[i].name == GO.name)
            {
                Debug.Log("Perk is already in a slot!");
                _isPerkInList = true;
            }
        }

        if (!_isPerkInList)
        {
            if (ListOfActivePerks.Count >= MaxAmountOfPerks)
            {
                ListOfActivePerks[ListIndex].GetComponent<UpgradePerk>().PerkImage.gameObject.transform.position = IconsResetPOS.transform.position;
                ListOfActivePerks.RemoveAt(ListIndex);
                Debug.Log("remove perk that was previously there");
            }
            ListOfActivePerks.Insert(ListIndex, GO);
            Debug.Log(GO.name + " Is enabled!");
        }
    }

    //Note, have it so when player clicks on the perk box they can switch it up with the code above.
    public void SetListIndexToFirstSlot() => ListIndex = 0;
    public void SetListIndexToSecondSlot() => ListIndex = 1;
    public void SetListIndexToThirdSlot() => ListIndex = 2;
    //move this to new script
    public void SetHighlight()
    {
        foreach (GameObject go in Highlights)
        {
            go.SetActive(false);
        }
        Highlights[ListIndex].SetActive(true);
    }

    public void PlaceIconsOnSlotsUI()
    {
        Debug.Log("place icon here");
        for (int i = 0; i < ListOfActivePerks.Count; i++)
        {
           ListOfActivePerks[i].GetComponent<UpgradePerk>().PerkImage.gameObject.transform.position = PosForImages[i].gameObject.transform.position;
        }
    }

    public void RemoveIconOnSlotsUI()
    {
        Debug.Log("remove icon on UI");
        PosForImages[ListIndex].gameObject.transform.position = IconsResetPOS.transform.position;
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
