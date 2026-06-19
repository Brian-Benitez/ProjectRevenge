using System.Collections.Generic;
using UnityEngine;

public class TypesOfEnemiesPerRoundController : MonoBehaviour
{
    [Header("Max enemies in round")]
    public int MaxAmountOfEnemies;
    public int MaxAmountOfBosses;

    [Header("Enemies")]
    public List<GameObject> InGameEnemies;
    public List<GameObject> EyeMosnters;
    public List<GameObject> SwordsmanGameObjects;
    public List<GameObject> AOEEnemies;
    public List<GameObject> ArchersGameObjects;
    public List<GameObject> Wizards;
    public GameObject BossGameObject;

    public RoundController RoundControllerRef;

    
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

            case 9://boss 
                NinthWaveEnemies();
                Debug.Log("this is round 10");
                break;


        }
    }

    void FirstWaveEnemies()
    {
        InGameEnemies.Add(EyeMosnters[0]);
    }

    void SecondWaveEnemies()
    {
        InGameEnemies.Add(EyeMosnters[0]);
        InGameEnemies.Add(SwordsmanGameObjects[0]);
        Debug.Log("added level one enemies");
    }

     void ThirdWaveEnemies()
     {
        InGameEnemies.Add(EyeMosnters[0]);
        InGameEnemies.Add(ArchersGameObjects[0]);
    }

    void FourthWaveEnemies()
    {
        InGameEnemies.Add(SwordsmanGameObjects[0]);
        InGameEnemies.Add(ArchersGameObjects[0]);
        Debug.Log("added both archers and swordsman as enemies");
    }

    void FifthWaveEnemies()
    {
        InGameEnemies.Add(SwordsmanGameObjects[1]);
        InGameEnemies.Add(ArchersGameObjects[1]);
        Debug.Log("added both archers and swordsman as enemies Lvl 2");
    }

    void SixthWaveEnemies()
    {
        InGameEnemies.Add(SwordsmanGameObjects[2]);
        InGameEnemies.Add(ArchersGameObjects[2]);
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
            InGameEnemies.Add(ArchersGameObjects[2]);
        }
        else if (isAllSwordsman)
        {
            InGameEnemies.Add(SwordsmanGameObjects[2]);
        }
    }

    void EighthWaveEnemies()
    {
        InGameEnemies.Add(Wizards[0]);
        InGameEnemies.Add(AOEEnemies[0]);
    }
    void NinthWaveEnemies() => InGameEnemies.Add(BossGameObject);

    public void RemoveAllEnemiesFromList() => InGameEnemies.Clear();
}
