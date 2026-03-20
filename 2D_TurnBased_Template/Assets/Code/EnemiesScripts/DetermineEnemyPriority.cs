using UnityEngine;

public class DetermineEnemyPriority : MonoBehaviour
{
    //DELETE ALL THIS
    [Header("Priority level")]
    public int EnemyPriorty;
    public bool IsFullAggro = false;

    [Header("Distances")]
    public float FightingDistance;
    public float StandByDistance;

    private void Update()
    {
        DeterminePriortyOnDistance(PlayerController.Instance.Player.gameObject);
    }
    public void DeterminePriortyOnDistance(GameObject playerpos)
    {
        float _distanceFromPlayer = Vector2.Distance(transform.position, playerpos.transform.position);  
        
        if(_distanceFromPlayer <= FightingDistance)
        {
            EnemyPriorty = 1;
        }
        if(_distanceFromPlayer <= StandByDistance && _distanceFromPlayer > FightingDistance)
        {
            EnemyPriorty = 2;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.darkOrange;
        Gizmos.DrawWireSphere(transform.position, StandByDistance);
        Gizmos.DrawWireSphere(transform.position, FightingDistance);
    }
}
