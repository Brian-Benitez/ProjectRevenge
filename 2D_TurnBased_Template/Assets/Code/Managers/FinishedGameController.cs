using UnityEngine;

public class FinishedGameController : MonoBehaviour
{
    public bool IsAtExit = false;
    public bool IsPlayerFinished = false;//might need this later...
    public GameObject EKeyGameObject;

    public MovingPlayerController MovingPlayerControllerRef;
    public MainMenuController MainMenuControllerRef;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsAtExit)
        {
            Debug.Log("player finished game");
            IsPlayerFinished = true;
            //Restart game here...
            MovingPlayerControllerRef.PlacePlayerInTutorialLevel();
            //add turn off player, and go back to main menu..... here.....
            MainMenuControllerRef.OpenMainMenuScreen();
            RestorePlayer();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EKeyGameObject.SetActive(true);
            IsAtExit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EKeyGameObject.SetActive(false);
            IsAtExit = false;
        }
    }

    public void RestorePlayer()
    {
        Debug.Log("healed and restored player.");
        PlayerAmmoController.Instance.AddAmmo(PlayerAmmoController.Instance.MaxAmmoAmount);
        PlayerController.Instance.Player.GetComponent<PlayerInfo>().CharacterHealthAmount = PlayerController.Instance.Player.GetComponent<PlayerInfo>().CharacterMaxHealth;
    }
}
