using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController : MonoBehaviour
{
    public static EnemyTurnController Instance;
    public List<GameObject> EnemiesAggroed;
    public int AmountOfDirectEnemyThreat;
    public int MaxAmountOfDirectEnemyThreat;
    public bool IsThereAnOpenSlot = false;
    private bool HaveBeenAdded = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        CheckOnAmountOfEnemyThreats();
    }


    public void AddEnemyToList(GameObject enemy)
    {
        HaveBeenAdded = false;
        foreach (GameObject item in EnemiesAggroed)
        {
            if (item.name == enemy.name)
            {
                Debug.Log("enemy is already in list");
                HaveBeenAdded = true;
            }
        }
        if (AmountOfDirectEnemyThreat == MaxAmountOfDirectEnemyThreat)
            Debug.Log("cannot add more enemies");
        else if(HaveBeenAdded  == false && AmountOfDirectEnemyThreat < MaxAmountOfDirectEnemyThreat)
        {
            EnemiesAggroed.Add(enemy);
            AddAsDirectThreat();
        }
        HaveBeenAdded = false;
    }

    public void RemoveEnemyFromList(GameObject enemy) => EnemiesAggroed.Remove(enemy);
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

    public void AddAsDirectThreat()
    {
        if (AmountOfDirectEnemyThreat > MaxAmountOfDirectEnemyThreat)
            AmountOfDirectEnemyThreat = MaxAmountOfDirectEnemyThreat;
        else
            AmountOfDirectEnemyThreat++;
    }
    public void RemoveAsDirectThreat()
    {
        if (AmountOfDirectEnemyThreat < 0)
            AmountOfDirectEnemyThreat = 0;
        else
            AmountOfDirectEnemyThreat--;
    }
}
