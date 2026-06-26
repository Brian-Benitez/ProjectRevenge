using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner Instance;

    [Header("Note: Only make enemies be an even amount of them")]
    public int EnemiesAlive;
    public bool IsAllEnemiesDead = false;
    [Header("Spawns Points")]
    public List<List<GameObject>> AllListOfSpawnPoints;
    public List<GameObject> SpawnPointACount8;
    public List<GameObject> SpawnPointBCount8;

    public TypesOfEnemiesPerRoundController TypesOfEnemiesPerRoundControllerRef;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        AllListOfSpawnPoints = new List<List<GameObject>>();
        AllListOfSpawnPoints.Add(SpawnPointACount8);
        AllListOfSpawnPoints.Add(SpawnPointBCount8);
    }


    public void PickASpawnPointAndSpawn()
    {
        int listindex = Random.Range(0, AllListOfSpawnPoints.Count);
        Debug.Log("this spawner: " + listindex);

        SpawnEnemiesOnSpawnPoints(AllListOfSpawnPoints[listindex]);
    }
    public void SpawnEnemiesOnSpawnPoints(List<GameObject> listofspawnpoints)
    {
        for (int i = 0; i < listofspawnpoints.Count; i++)
        {
            //spawn enemies here...
            EnemiesAlive++;
            if (TypesOfEnemiesPerRoundControllerRef.InGameEnemies.Count == 1)
            {
                Instantiate(TypesOfEnemiesPerRoundControllerRef.InGameEnemies[0], listofspawnpoints[i].transform.position, Quaternion.identity);
            }
            else if (TypesOfEnemiesPerRoundControllerRef.InGameEnemies.Count == 2)
            {
                Instantiate(TypesOfEnemiesPerRoundControllerRef.InGameEnemies[0], listofspawnpoints[i].transform.position, Quaternion.identity);
                Instantiate(TypesOfEnemiesPerRoundControllerRef.InGameEnemies[1], listofspawnpoints[i].transform.position, Quaternion.identity);
                EnemiesAlive++;
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
