using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject MainMenuPrefab;
    public GameObject GameOverPrefab;
    public GameObject LevelUpPrefab;
    public List<UpgradePerk> AllPerks;
    public List<LevelUpStat> AllStats;
    [Header("Scripts")]
    public RoundController RoundControllerRef;
    public PlayerInfo PlayerInfoRef;
    public TypesOfEnemiesPerRoundController TypesOfEnemiesPerRoundControllerRef;

    public void GoToMainMenu()
    {
        GameOverPrefab.SetActive(false);
        MainMenuPrefab.SetActive(true);
    }
    public void TurnOnGameOverScreen()
    {
        GameOverPrefab.SetActive(true);
    }

    public void RestartGame() 
    {
        PlayerInfoRef.PlayersCore.SetActive(true);
        TypesOfEnemiesPerRoundControllerRef.RemoveAllEnemiesFromList();
        PlayerInfoRef.IsCharacterDead = false;
        PlayerInfoRef.HealthBarUIRef.SetUIHealth(PlayerInfoRef.BaseLineHealth);
        PlayerInfoRef.SetHealth(PlayerInfoRef.BaseLineHealth);
        GameOverPrefab.SetActive(false);
        RoundControllerRef.RoundsCounter = 0;
        RoundControllerRef.TotalAmountOfRoundsWon = 0;
        SoulsBankController.instance.DemonBossSoulsBank = 0;
        SoulsBankController.instance.SoulsBank = 0;
        PlayerSpawnerController.Instance.SpawnPlayer();
        RestartAllPlayersPerks();
        RestartAllPlayersStats();
        LevelUpPrefab.SetActive(true); 
    }

    void RestartAllPlayersPerks()
    {
        for (int i = 0; i < AllPerks.Count; i++)
        {
            AllPerks[i].DisablePerk();
        }
    }

    void RestartAllPlayersStats()
    {
        for (int i = 0; i < AllStats.Count; i++)
        {
            AllStats[i].RestartStat();
        }

    }
}
