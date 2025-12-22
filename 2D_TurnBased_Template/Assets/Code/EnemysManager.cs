using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{
    public static EnemysManager Instance;
    //Enemy list
    public List<List<GameObject>> AllEnemies;//need to work on this

    [Header("Current active enemies")]
    public int CurrentEnemyCount = 0;

    [Header("Wave index")]
    public int EnemyWaveIndex = 0;

    [Header("All Enemies in level in order")]
    public List<GameObject> EnemyWave;

    [Header("All Doors in level")]
    public List<GameObject> AllDoorsInLevel;

    public List<GameObject> TriggerFightGOs;
    public int FightIdIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        AllEnemies = new List<List<GameObject>>();
        Debug.Log("look here" +  AllEnemies.Count); 
    }
 
    /// <summary>
    /// Closes all doors then spawn all enemies. 
    /// </summary>
    public void SpawnEnemies()
    {
        Debug.Log("spawning enemies now...");
        CloseAllDoorsInLevel();
        CurrentEnemyCount  = AllEnemies[FightIdIndex].Count;
        foreach(GameObject enemies in AllEnemies[FightIdIndex])
        {
            enemies.SetActive(true);
        }
    }


    public void IsAllEnemiesDead()
    {
        if (CurrentEnemyCount == 0)
            OpenAllDoorsInLevel();
        else
            Debug.Log("enemies are still alive");
    }

    /// <summary>
    /// Close all doors for battle.
    /// </summary>
    void CloseAllDoorsInLevel()
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
