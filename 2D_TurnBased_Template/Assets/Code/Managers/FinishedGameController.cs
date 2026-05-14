using UnityEngine;

public class FinishedGameController : MonoBehaviour
{
    public bool IsAtExit = false;
    public GameObject EKeyGameObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsAtExit)
        {
            Debug.Log("player finished game");
            //add turn off player, and go back to main menu..... here.....
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
}
