using UnityEngine;

public class TriggerFight : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("spawn enemies now");
            EnemysManager.Instance.SpawnEnemies();
        }
    }
}
