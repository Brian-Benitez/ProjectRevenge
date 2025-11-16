using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemysManager : MonoBehaviour
{
    public static EnemysManager Instance;
    //Enemy list
    public List<List<GameObject>> AllEnemies;

    [Header("Wave index")]
    public int EnemyWaveIndex = 0;

    [Header("All Enemies in level in order")]
    public List<GameObject> FirstEnemyWave;
    public List<GameObject> SecondEnemyWave;
    public List<GameObject> LastEnemyWave;

    [Header("All Doors in level")]
    public List<GameObject> AllDoorsInLevel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        AllEnemies = new List<List<GameObject>>();
        AllEnemies.Add(FirstEnemyWave);
        AllEnemies.Add(SecondEnemyWave);
        AllEnemies.Add(LastEnemyWave);
        Debug.Log("look here" +  AllEnemies.Count); 
    }
    private void Update()
    {
        //if (AllEnemies[0].Count == 0)
            //Debug.Log("everyone died");
    }
    /// <summary>
    /// Closes all doors then spawn all enemies. 
    /// </summary>
    public void SpawnEnemies()
    {
        Debug.Log("spawning enemies now...");
        CloseAllDoorsInLevel();

        foreach(GameObject enemies in AllEnemies[EnemyWaveIndex])
        {
            enemies.SetActive(true);
        }
        EnemyWaveIndex++;
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
