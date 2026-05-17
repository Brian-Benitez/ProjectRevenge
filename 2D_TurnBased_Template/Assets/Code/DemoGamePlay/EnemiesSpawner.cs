using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner Instance;

    [Header("Note: Only make enemies be an even amount of them")]
    public int EnemiesAlive;
    public bool IsAllEnemiesDead = false;
    [Header("Spawns Points")]
    public List<GameObject> SpawnPoints;

    public TypesOfEnemiesPerRoundController TypesOfEnemiesPerRoundControllerRef;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnEnemiesOnSpawnPoints()
    {
        int amountOfEnemiesPerSpawn = TypesOfEnemiesPerRoundControllerRef.MaxAmountOfEnemies / 4;
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            for (int j = 0; j < amountOfEnemiesPerSpawn; j++)
            {
                //spawn enemies here...
                EnemiesAlive++;
                if(TypesOfEnemiesPerRoundControllerRef.InGameEnemies.Count == 1)
                {
                    Instantiate(TypesOfEnemiesPerRoundControllerRef.InGameEnemies[0], SpawnPoints[i].transform.position, Quaternion.identity);
                }
                else if(TypesOfEnemiesPerRoundControllerRef.InGameEnemies.Count == 2)
                {
                    Instantiate(TypesOfEnemiesPerRoundControllerRef.InGameEnemies[0], SpawnPoints[i].transform.position, Quaternion.identity);
                    Instantiate(TypesOfEnemiesPerRoundControllerRef.InGameEnemies[1], SpawnPoints[i].transform.position, Quaternion.identity);
                    EnemiesAlive++;
                }
            }
        }
    }
    public void CheckOnTotalEnemies()
    {
        if (EnemiesAlive <= 0)
            IsAllEnemiesDead = true;
        else
            IsAllEnemiesDead = false;
    }
}
