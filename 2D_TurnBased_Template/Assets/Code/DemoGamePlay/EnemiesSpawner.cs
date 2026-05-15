using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner Instance;

    [Header("Note: Only make enemies be an even amount of them")]
    public int AmountOfEnemies;
    public int MaxAmountOfEnemies;
    public bool IsAllEnemiesDead = false;
    [Header("Swordsman GameObject")]
    public GameObject LevelOneSwordman;
    public GameObject LevelTwoSwordman;
    public GameObject LevelThreeSwordman;
    [Header("Archers GameObject")]
    public GameObject LevelOneArcher;
    public GameObject LevelTwoArcher;
    public GameObject LevelThreeArcher;
    [Header("Spawns Points")]
    public List<GameObject> SpawnPoints;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnEnemiesOnSpawnPoints()
    {
        //MaxAmountOfEnemies += 3;
        //AmountOfEnemies = MaxAmountOfEnemies;
        int dividedAmountOfEnmies = AmountOfEnemies / 2;
        int enemiesSpawnedInTotal = 0;
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            if(enemiesSpawnedInTotal != AmountOfEnemies)
            {
                for (int j = 0; j < dividedAmountOfEnmies; j++)
                {
                    enemiesSpawnedInTotal++;
                    Instantiate(LevelOneSwordman, SpawnPoints[i].transform.position, Quaternion.identity);
                }
            }
        }
    }
    public void CheckOnTotalEnemies()
    {
        if (AmountOfEnemies <= 0)
            IsAllEnemiesDead = true;
        else
            IsAllEnemiesDead = false;
    }
}
