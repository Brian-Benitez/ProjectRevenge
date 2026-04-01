using System.Collections;
using UnityEngine;

public class PausingState : State
{
    public bool TimerIsDone = false;
    public float WaitTime;// NOTE DO NOT GO TO 5 SEC IT WILL BREAK 
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public PatrolState PatrolState;

    IEnumerator PauseOnArrival()
    {
        TimerIsDone = false;
        Debug.Log("look here");
        yield return new WaitForSeconds(WaitTime);
        TimerIsDone = true;
        Debug.Log("imdone");
    }
    public override State RunCurrentState()
    {
        if(TimerIsDone)
            return PatrolState;
        else if(PatrolState.IsOnFirstPoint || PatrolState.IsOnSecondPoint && !TimerIsDone)
        {
            StartCoroutine(PauseOnArrival());   
        }
        return this;
    }
}
