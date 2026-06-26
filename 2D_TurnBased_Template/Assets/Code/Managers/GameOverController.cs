using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject MainMenuPrefab;
    public GameObject GameOverPrefab;
    public List<UpgradePerk> AllPerks;
    [Header("Scripts")]
    public RoundController RoundControllerRef;

    public void GoToMainMenu()
    {
        GameOverPrefab.SetActive(false);
        MainMenuPrefab.SetActive(true);
    }

    public void RestartGame()
    {
        RoundControllerRef.RoundsCounter = 0;
        RoundControllerRef.TotalAmountOfRoundsWon = 0;
        SoulsBankController.instance.DemonBossSoulsBank = 0;
        SoulsBankController.instance.SoulsBank = 0;
        PlayerSpawnerController.Instance.SpawnPlayer();
    }

    void RestartAllPerks()
    {
        for (int i = 0; i < AllPerks.Count; i++)
        {
            AllPerks[i].DisablePerk();
        }
    }

    void RetstartAllUpgrades()
    {

    }
}
