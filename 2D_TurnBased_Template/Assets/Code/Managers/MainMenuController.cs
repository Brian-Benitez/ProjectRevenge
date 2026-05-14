using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject StartMenuPrefab;
    public GameObject OptionsMenuPrefab;

    private void Start()
    {
        StartMenuPrefab.SetActive(true);
    }
    public void OpenMainMenuScreen()
    {
        //fade to black
        StartMenuPrefab.SetActive(true);
    }
    public void StartingGame()
    {
        //add fade to black...
        StartMenuPrefab.SetActive(false);
        //place player in tutorial area...
    }

    public void OptionMenuOpen()
    {
        //add small pop up on menu...
        Debug.Log("does not have menu made yet...");
        //OptionsMenuPrefab.SetActive(true);
    }
    public void QuitGame() => Application.Quit();
}
