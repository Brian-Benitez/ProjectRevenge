using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemysManager : MonoBehaviour
{
    public static EnemysManager Instance;

    [Header("All Fight boxes")]
    public List<TriggerFight> TriggerFights;
    public int CurrentTriggerIndex;

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

    public void CheckIfTriggerIsCleared()
    {
        foreach(TriggerFight trigger in TriggerFights)
        {
            if(trigger.Enemies.Count <= 0)
                trigger.gameObject.SetActive(false);
            else
                trigger.gameObject.SetActive(true); 
        }
    }

    public void EnableIsFullAggro()
    {
        int _countofEnemies = 0;

        if(TriggerFights[CurrentTriggerIndex].Enemies.Count == 0)
        {
            Debug.Log("there are no enemies left to be aggro to");
        }
        else
        {
            for (int i = 0; i < TriggerFights[CurrentTriggerIndex].Enemies.Count; i++)
            {
                if (TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponent<BaseEnemy>().EnemyType == BaseEnemy.TypeOfEnemy.Swordsman)
                {
                    if (TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponentInChildren<DetermineEnemyPriority>().IsFullAggro == false)
                    {
                        _countofEnemies++;
                        Debug.Log("is not aggro");
                    }
                    if (_countofEnemies == TriggerFights[CurrentTriggerIndex].Enemies.Count)
                    {
                        TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponentInChildren<DetermineEnemyPriority>().IsFullAggro = true;
                    }
                }  
            }
        } 
    }

   /// <summary>
   /// Heals all enemies but does not reactive all of them
   /// </summary>
    public void HealsEnemiesInSection() => TriggerFights.ToList().ForEach(e => e.RestartAllEnemies());

    public void TurnOffEnemyFullAggroBool()
    {
        //TriggerFights[CurrentTriggerIndex].toList()
    }

    /// <summary>
    /// This calls when enemy is killed, then is removed from  trigger fights list of enemies
    /// </summary>
    /// <param name="enemy"></param>
    public void RemoveEnemyFromList(GameObject enemy)
    {
        TriggerFights[CurrentTriggerIndex].Enemies.Remove(enemy);
        Debug.Log("removing self from list");
    }
    public void IsAllEnemiesDead()
    {
        if (TriggerFights[CurrentTriggerIndex].Enemies.Count <= 0)
        {
            DoorController.instance.OpenAllDoorsInLevel();
        }
    }
}
