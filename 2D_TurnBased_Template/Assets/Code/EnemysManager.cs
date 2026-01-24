using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{
    public static EnemysManager Instance;//gotta split this later, no door controller here breaking SRP
 
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            EnableIsFullAggro();
        }
    }

    public void DisableTrigger(int UsedFightId)
    {
        foreach(TriggerFight triggers in TriggerFights)
        {
            if(triggers.FightID == UsedFightId)
                triggers.gameObject.SetActive(false);

            //triggers.Enemies[0].GetComponent<DetermineEnemyPriority>().IsFullAggro = true;
        }
    }

    public void EnableIsFullAggro()
    {
        foreach(TriggerFight triggers in TriggerFights)
        {
            int _countofEnemies = 0;

            for (int i = 0; i < triggers.Enemies.Count; i++)
            {
                if (triggers.Enemies[i].GetComponentInChildren<DetermineEnemyPriority>().IsFullAggro == false)
                {
                    _countofEnemies++;
                    Debug.Log("is not aggro");
                }

                if (_countofEnemies == triggers.Enemies.Count)
                {
                    triggers.Enemies[0].GetComponentInChildren<DetermineEnemyPriority>().IsFullAggro = true;
                }
            }
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
