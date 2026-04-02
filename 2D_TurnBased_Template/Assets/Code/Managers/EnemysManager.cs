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


    public void EnableCurrentTriggerBox()
    {
        foreach (TriggerFight trigger in TriggerFights)
        {
            if (trigger.FightID == CurrentTriggerIndex)
                trigger.gameObject.SetActive(true);
        }
    }
    public void DisableTrigger(int UsedFightId)
    {
        foreach(TriggerFight triggers in TriggerFights)
        {
            if(triggers.FightID == UsedFightId)
                triggers.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// This restarts enemies and places them where they belong
    /// </summary>
    public void RepositionAllEnemiesInLevel()
    {
        for (int i = 0; i < TriggerFights[CurrentTriggerIndex].Enemies.Count; i++)
        {
            if (TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponent<BaseEnemy>().IsDead)
            {
                TriggerFights[CurrentTriggerIndex].Enemies[i].gameObject.SetActive(true);
                TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponent<BaseEnemy>().IsDead = false;
                TriggerFights[CurrentTriggerIndex].Enemies[i].transform.position = TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponentInChildren<PatrolState>().PatrolSpotOne.transform.position;
            }
        }
    }
    /// <summary>
    /// Turn off all the most recent enemies the player fought
    /// </summary>
    public void RestartAndTurnOffEnemies()
    {
        for (int i = 0; i < TriggerFights[CurrentTriggerIndex].Enemies.Count; i++)
        {
            if (TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponent<BaseEnemy>().EnemyType == BaseEnemy.TypeOfEnemy.Swordsman)
            {
                TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponentInChildren<AttackState>().RestartEnemy();
            }

            TriggerFights[CurrentTriggerIndex].Enemies[i].SetActive(false);
        }
    }

    public void IsAllEnemiesDead()
    {
        int _coutOfDisabledEnemies = 1;

        for (int i = 0; i < TriggerFights[CurrentTriggerIndex].Enemies.Count; i++)
        {
            if (TriggerFights[CurrentTriggerIndex].Enemies[i].GetComponent<BaseEnemy>().IsDead)
            {
                _coutOfDisabledEnemies++;
                Debug.Log("added one dead");
            }
            if (TriggerFights[CurrentTriggerIndex].Enemies.Count == _coutOfDisabledEnemies)
            {
                DoorController.instance.OpenAllDoorsInLevel();
                Debug.Log("open door");
            }
                
        }
    }

    /// <summary>
    /// Activates all eneimes in section recntly fought
    /// </summary>
    public void ActivateAllEnemies() => TriggerFights[CurrentTriggerIndex].Enemies.ToList().ForEach(enemies => enemies.gameObject.SetActive(true));

    /// <summary>
    /// Heals all enemies in section recently fought
    /// </summary>
    public void HealsEnemiesInSection() => TriggerFights[CurrentTriggerIndex].Enemies.ToList().ForEach(e => e.GetComponent<BaseEnemy>().HealSelfFully());

}
