using UnityEngine;
using UnityEngine.Rendering;

public class HealthPickUp : BasePickUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealPlayer();
            PlayerController.Instance.Player.GetComponent<BaseCharacter>().UpdatePlayersStats();
            Debug.Log("healed");
            Destroy(gameObject);
        }
    }
}
