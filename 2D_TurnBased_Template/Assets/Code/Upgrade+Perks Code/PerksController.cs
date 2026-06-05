using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PerksController : MonoBehaviour
{
    public static PerksController Instance;
    public int MaxAmountOfPerks;
    public List<GameObject> ListOfActivePerks;
    [Header("UIs")]
    public GameObject AllPerksUI;
    public GameObject PerksUIGO;
    public GameObject LevelUpUIGO;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void AddPerkToList(GameObject GO)
    {
        bool _isPerkInList = false;
        if (ListOfActivePerks.Count < MaxAmountOfPerks)
        {
            for (int i = 0; i < ListOfActivePerks.Count; i++)
            {
                if (ListOfActivePerks[i].name == GO.name)
                {
                    Debug.Log("Perk is already in a slot!");
                    _isPerkInList = true;
                }
            }

            if(!_isPerkInList)
            {
                ListOfActivePerks.Add(GO);
                Debug.Log(GO.name + " IS ENBALED!");
            }
        }
        else
            Debug.Log("All Perk Slots Are Filled!");
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
