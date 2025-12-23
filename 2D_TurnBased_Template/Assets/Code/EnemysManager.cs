using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{
    public static EnemysManager Instance;
 
    [Header("All Doors in level")]
    public List<GameObject> AllDoorsInLevel;

    public int CurrentEnemyAmount;

    public List<TriggerFight> TriggerFights;
    public int LastTriggerIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void DisableTrigger(int UsedFightId)
    {
        foreach(TriggerFight triggers in TriggerFights)
        {
            if(triggers.FightID == UsedFightId)
                triggers.gameObject.SetActive(false);
        }
    }

    public void IsAllEnemiesDead()
    {
        if (CurrentEnemyAmount <= 0)
            OpenAllDoorsInLevel();
        else
            Debug.Log("enemies still about");
    }

    /// <summary>
    /// Close all doors for battle.
    /// </summary>
    public void CloseAllDoorsInLevel()
    {
        foreach(GameObject Door in AllDoorsInLevel)
        {
            Door.SetActive(true);
        }
    }
    /// <summary>
    /// Open all doors after battle is done.
    /// </summary>
    public void OpenAllDoorsInLevel()
    {
        foreach (GameObject Door in AllDoorsInLevel)
        {
            Door.SetActive(false);
        }
    }
}
