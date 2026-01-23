using System.Collections.Generic;
using UnityEngine;

public class DetermineEnemyPriority : MonoBehaviour
{
    [Header("Priority level")]
    public int EnemyPriorty;

    [Header("Distances")]
    public float CloseAggroDistance;
    public float CloseStandbyDistance;
    public float FarWaitingDistance;

    private void Update()
    {
        DeterminePriortyOnDistance(PlayerController.Instance.Player.gameObject);
    }
    public void DeterminePriortyOnDistance(GameObject playerpos)
    {
        float _distanceFromPlayer = Vector2.Distance(transform.position, playerpos.transform.position);  
        
        if(_distanceFromPlayer <= CloseAggroDistance)
        {
            EnemyPriorty = 1;
        }
        if(_distanceFromPlayer <= CloseStandbyDistance && _distanceFromPlayer > CloseAggroDistance)
        {
            EnemyPriorty = 2;
        }
        if(_distanceFromPlayer >= FarWaitingDistance)
        {
            EnemyPriorty = 3;
        }
    }
}
