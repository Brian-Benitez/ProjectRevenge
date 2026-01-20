using UnityEngine;

public class EnemyAggroDistance : MonoBehaviour
{
    [Header("Radius Attack Info")]
    public bool IsAggro = false;
    public float AggroDistance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IsAggro = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, AggroDistance);
    }
}
