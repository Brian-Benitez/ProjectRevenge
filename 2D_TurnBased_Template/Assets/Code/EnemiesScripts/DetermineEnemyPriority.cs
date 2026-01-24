using System.Collections.Generic;
using UnityEngine;

public class DetermineEnemyPriority : MonoBehaviour
{
    [Header("Priority level")]
    public int EnemyPriorty;

    [Header("Distances")]
    public float OnePriorityDistance;
    public float TwoPriorityDistance;

    private void Update()
    {
        DeterminePriortyOnDistance(PlayerController.Instance.Player.gameObject);
    }
    public void DeterminePriortyOnDistance(GameObject playerpos)
    {
        float _distanceFromPlayer = Vector2.Distance(transform.position, playerpos.transform.position);  
        
        if(_distanceFromPlayer <= OnePriorityDistance)
        {
            EnemyPriorty = 1;
        }
        if(_distanceFromPlayer <= TwoPriorityDistance && _distanceFromPlayer > OnePriorityDistance)
        {
            EnemyPriorty = 2;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.darkOrange;
        Gizmos.DrawWireSphere(transform.position, TwoPriorityDistance);
        Gizmos.DrawWireSphere(transform.position, OnePriorityDistance);
    }
}
