using UnityEngine;

public class TriggerFight : MonoBehaviour
{
    public int FightID;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("spawn enemies now");
            EnemysManager.Instance.FightIdIndex = FightID;
            EnemysManager.Instance.SpawnEnemies();
        }
    }
}
