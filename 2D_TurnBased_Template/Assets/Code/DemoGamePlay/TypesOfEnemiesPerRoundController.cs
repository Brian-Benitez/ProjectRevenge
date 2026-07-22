using System.Collections.Generic;
using UnityEngine;

public class TypesOfEnemiesPerRoundController : MonoBehaviour
{
    [Header("Max enemies in round")]
    public int MaxAmountOfEnemies;
    public int MaxAmountOfBosses;

    [Header("Enemies")]
    public List<GameObject> ListOfEnemies;
    public List<GameObject> TypesOfInGameEnemies;
    public List<GameObject> EyeMosnters;
    public List<GameObject> SwordsmanGameObjects;
    public List<GameObject> AOEEnemies;
    public List<GameObject> ArchersGameObjects;
    public List<GameObject> Wizards;
    public GameObject BossGameObject;

    public RoundController RoundControllerRef;
    public EnemiesSpawner EnemiesSpawnerRef;
    public UpgradeEnemiesController UpgradeEnemiesControllerRef;

    
    public void TypeOfEnemiesForRound()
    {
        switch (RoundControllerRef.RoundsCounter)
        {
            case 0://just level one sword enemies
                FirstWaveEnemies();
                Debug.Log("this is round 1");
                break;

            case 1://level one archers and swords
                SecondWaveEnemies();
                break;

            case 2://level two archers and swords
                ThirdWaveEnemies();
                break;

            case 3://level three archers and swords
                FourthWaveEnemies();
                break;

            case 4://either all archers or swords lvl 3
                FifthWaveEnemies();
                break;

            case 5:
                SixthWaveEnemies();
                break;

            case 6:
                SeventhWaveEnemies();
                break;

            case 7:
                EighthWaveEnemies();
                break;
            
            case 8:
                Debug.Log("whats up");
                break;

            case 9://boss 
                NinthWaveEnemies();
                Debug.Log("this is round 10");
                break;


        }
    }

    void FirstWaveEnemies()
    {
        TypesOfInGameEnemies.Add(EyeMosnters[0]);
    }

    void SecondWaveEnemies()
    {
        TypesOfInGameEnemies.Add(EyeMosnters[0]);
        TypesOfInGameEnemies.Add(SwordsmanGameObjects[0]);
        Debug.Log("added level one enemies");
    }

     void ThirdWaveEnemies()
     {
        TypesOfInGameEnemies.Add(EyeMosnters[0]);
        TypesOfInGameEnemies.Add(ArchersGameObjects[0]);
    }

    void FourthWaveEnemies()
    {
        TypesOfInGameEnemies.Add(SwordsmanGameObjects[0]);
        TypesOfInGameEnemies.Add(ArchersGameObjects[0]);
        Debug.Log("added both archers and swordsman as enemies");
    }

    void FifthWaveEnemies()
    {
        TypesOfInGameEnemies.Add(SwordsmanGameObjects[1]);
        TypesOfInGameEnemies.Add(ArchersGameObjects[1]);
        Debug.Log("added both archers and swordsman as enemies Lvl 2");
    }

    void SixthWaveEnemies()
    {
        TypesOfInGameEnemies.Add(SwordsmanGameObjects[2]);
        TypesOfInGameEnemies.Add(ArchersGameObjects[2]);
        Debug.Log("added both archers and swordsman as enemies Lvl 3");
    }

    void SeventhWaveEnemies()
    {
        bool isAllArchers = false;
        bool isAllSwordsman = false;//can add more later and more unique

        int results = Random.Range(0, 1);
        if (results == 0)
        {
            isAllArchers = true;
            Debug.Log("is a all archer turn");
        }
        else if (results == 1)
        {
            Debug.Log("is a all swordsman turn");
            isAllSwordsman = true;
        }

        if (isAllArchers)
        {
            TypesOfInGameEnemies.Add(ArchersGameObjects[2]);
        }
        else if (isAllSwordsman)
        {
            TypesOfInGameEnemies.Add(SwordsmanGameObjects[2]);
        }
    }

    void EighthWaveEnemies()
    {
        TypesOfInGameEnemies.Add(Wizards[0]);
        TypesOfInGameEnemies.Add(AOEEnemies[0]);
    }
    void NinthWaveEnemies() => TypesOfInGameEnemies.Add(BossGameObject);

    public void RemoveAllEnemiesFromList()
    {
        if(ListOfEnemies != null)
        {
            for (int i = 0; i < ListOfEnemies.Count; i++)
            {
                Destroy(ListOfEnemies[i]);
            }
        }
       
        TypesOfInGameEnemies.Clear();
        ListOfEnemies.Clear();
        EnemiesSpawnerRef.EnemiesAlive = 0;
        EnemiesSpawnerRef.IsAllEnemiesDead = true;
    }

    public void UpgradeAllEnemies()
    {
        UpgradeEnemiesControllerRef.UpgradeEnemyShields(EyeMosnters);
        UpgradeEnemiesControllerRef.UpgradeEnemyShields(SwordsmanGameObjects);
        UpgradeEnemiesControllerRef.UpgradeEnemyShields(AOEEnemies);
        UpgradeEnemiesControllerRef.UpgradeEnemyShields(ArchersGameObjects);
        UpgradeEnemiesControllerRef.UpgradeEnemyShields(Wizards);
    }
}
