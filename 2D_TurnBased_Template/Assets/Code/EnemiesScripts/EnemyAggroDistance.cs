using UnityEngine;

public class EnemyAggroDistance : MonoBehaviour
{
    [Header("Radius Attack Info")]
    public bool IsAggro = false;
    public bool IsFightingPlayer = false;
    public float AggroDistance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IsAggro = true;
            EnemyTurnController.Instance.TryAddingEnemyToList(this.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnemyTurnController.Instance.RemoveEnemyFromList(this.gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, AggroDistance);
    }
}
