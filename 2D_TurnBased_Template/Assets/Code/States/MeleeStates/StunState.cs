using System.Collections;
using UnityEngine;

public class StunState : State
{
    private float MaxStunTime;


    public BaseEnemy BaseEnemyRef;
    public MovementState MovementStateRef;

    private void Start()
    {
        MaxStunTime = BaseEnemyRef.StunDuration;
    }

    public IEnumerator StunLocked()
    {
        Debug.Log("im running");
        BaseEnemyRef.IsStunned = true;
        Debug.Log("im here");
        yield return new WaitForSeconds(MaxStunTime);
        Debug.Log("did i make it");
        BaseEnemyRef.IsStunned = false;
        Debug.Log("im done");
    }
    public override State RunCurrentState()
    {
        if (BaseEnemyRef.IsStunned == false)
            return MovementStateRef;

        else if (BaseEnemyRef.IsStunned)
            StartCoroutine(StunLocked());
        return this;
    }
}
