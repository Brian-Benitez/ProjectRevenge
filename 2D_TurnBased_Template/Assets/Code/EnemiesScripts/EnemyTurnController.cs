using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController : MonoBehaviour
{
    public static EnemyTurnController Instance;
    public List<GameObject> EnemiesFightingPlayer;
    public int AmountOfDirectEnemyThreat;
    public int MaxAmountOfDirectEnemyThreat;
    public bool IsThereAnOpenSlot = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        CheckOnAmountOfEnemyThreats();
    }

    public bool IsEnemyInList(GameObject enemy)
    {
        if(enemy.GetComponentInChildren<EnemyAggroDistance>().IsFightingPlayer)
            return true;
        else
            return false;
    }
    public void TryAddingEnemyToList(GameObject enemy)
    {
        if (AmountOfDirectEnemyThreat == MaxAmountOfDirectEnemyThreat)
            Debug.Log("cannot add more enemies");
        else if(enemy.GetComponentInChildren<EnemyAggroDistance>().IsFightingPlayer == false && AmountOfDirectEnemyThreat < MaxAmountOfDirectEnemyThreat)
        {
            EnemiesFightingPlayer.Add(enemy);
            AddAsDirectThreat();
            enemy.GetComponentInChildren<EnemyAggroDistance>().IsFightingPlayer = true;
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        if(EnemiesFightingPlayer.Count > 1)
        {
            EnemiesFightingPlayer.Remove(enemy);
            enemy.GetComponentInChildren<EnemyAggroDistance>().IsFightingPlayer = false;
        }
    }
    /// <summary>
    /// Checks to see if there any slots left to fight the player.
    /// </summary>
    public void CheckOnAmountOfEnemyThreats()
    {
        if (AmountOfDirectEnemyThreat == MaxAmountOfDirectEnemyThreat)
            IsThereAnOpenSlot = false;
        else
            IsThereAnOpenSlot = true;
    }

    private void AddAsDirectThreat()
    {
        if (AmountOfDirectEnemyThreat > MaxAmountOfDirectEnemyThreat)
            AmountOfDirectEnemyThreat = MaxAmountOfDirectEnemyThreat;
        else
            AmountOfDirectEnemyThreat++;
    }
    public void RemoveAsDirectThreat()
    {
        if (AmountOfDirectEnemyThreat <= 0)
            AmountOfDirectEnemyThreat = 0;
        else
            AmountOfDirectEnemyThreat--;
    }
}
