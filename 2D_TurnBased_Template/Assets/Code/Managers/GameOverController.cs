using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject MainMenuPrefab;
    public GameObject GameOverPrefab;

    public void GoToMainMenu()
    {
        GameOverPrefab.SetActive(false);
        MainMenuPrefab.SetActive(true);
    }

    public void RestartGame()
    {

    }
}
