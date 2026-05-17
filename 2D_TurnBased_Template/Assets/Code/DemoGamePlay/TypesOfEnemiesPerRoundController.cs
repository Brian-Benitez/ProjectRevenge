using System.Collections.Generic;
using UnityEngine;

public class TypesOfEnemiesPerRoundController : MonoBehaviour
{
    public int RoundCounter;
    public int RoundInterationCounter;

    [Header("Max enemies in round")]
    public int MaxAmountOfEnemies;
    public int MaxAmountOfBosses;

    [Header("Enemies")]
    public List<GameObject> InGameEnemies;
    public List<GameObject> SwordsmanGameObjects;
    public List<GameObject> ArchersGameObjects;
    public GameObject BossGameObject;

    public void IncreaseRoundCounter()
    {
        if (RoundCounter == 5)
            RoundCounter = 0;
        else
            RoundCounter += Mathf.Clamp(1, 0, 5);
    }
    public void TypeOfEnemiesForRound()
    {
        switch (RoundCounter)
        {
            case 0://just level one sword enemies
                FirstWaveEnemies();
                Debug.Log("this is round 1");
                break;

            case 1://level one archers and swords
                SecondWaveEnemies();
                Debug.Log("this is round 2");
                break;

            case 2://level two archers and swords
                ThirdWaveEnemies();
                Debug.Log("this is round 3");
                break;

            case 3://level three archers and swords
                FourthWaveEnemies();
                Debug.Log("this is round 4");
                break;

            case 4://either all archers or swords lvl 3
                FifthWaveEnemies();
                Debug.Log("this is round 5");
                break;

            case 5://boss 
                SixthWaveEnemies();
                Debug.Log("this is round 6");
                break;


        }
    }

    void FirstWaveEnemies()
    {
        InGameEnemies.Add(SwordsmanGameObjects[0]);
        Debug.Log("added level one enemies");
    }

    void SecondWaveEnemies()
    {
        InGameEnemies.Add(SwordsmanGameObjects[0]);
        InGameEnemies.Add(ArchersGameObjects[0]);
        Debug.Log("added both archers and swordsman as enemies");
    }

     void ThirdWaveEnemies()
     {
        InGameEnemies.Add(SwordsmanGameObjects[1]);
        InGameEnemies.Add(ArchersGameObjects[1]);
        Debug.Log("added both archers and swordsman as enemies Lvl 2");
     }

    void FourthWaveEnemies()
    {
        InGameEnemies.Add(SwordsmanGameObjects[2]);
        InGameEnemies.Add(ArchersGameObjects[2]);
        Debug.Log("added both archers and swordsman as enemies Lvl 3");
    }

    void FifthWaveEnemies()
    {
        bool isAllArchers = false;
        bool isAllSwordsman = false;//can add more later and more unique

        int results = Random.Range(0, 1);
        if(results == 0)
        {
            isAllArchers = true;
            Debug.Log("is a all archer turn");
        }
        else if(results == 1)
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

    void SixthWaveEnemies()
    {
        InGameEnemies.Add(BossGameObject);
    }

    public void RemoveAllEnemiesFromList() => InGameEnemies.Clear();
}
