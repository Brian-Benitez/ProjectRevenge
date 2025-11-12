using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class StunState : State
{
    [SerializeField]
    private float MaxStunTime;

    BaseEnemy BaseEnemyRef;
    ChaseState ChaseStateRef;

    private void Start()
    {
        BaseEnemyRef = GetComponent<BaseEnemy>();
        ChaseStateRef = GetComponent<ChaseState>(); 
        MaxStunTime = BaseEnemyRef.StunDuration;
    }

    public IEnumerator StunLocked()
    {
        StopAllCoroutines();    
        BaseEnemyRef.IsStunned = true;
        Debug.Log("enemy is stunned!");
        yield return new WaitForSeconds(MaxStunTime);
        BaseEnemyRef.IsStunned = false;
    }
    public override State RunCurrentState()
    {
        if (BaseEnemyRef.IsStunned == false)
            return ChaseStateRef;

        else if (BaseEnemyRef.IsStunned)
            StartCoroutine(StunLocked());
        return this;
    }
}
