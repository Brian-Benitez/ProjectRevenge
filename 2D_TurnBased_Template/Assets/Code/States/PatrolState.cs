using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : State
{
    public GameObject PatrolSpotOne;
    public GameObject PatrolSpotTwo;
    public GameObject EnemyGO;

    public bool IsOnFirstPoint = false;
    public bool IsOnSecondPoint = false;    
    public bool IsWaitingOnPoint = false;

    public BaseEnemy BaseEnemyRef;
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public MovementState MovementStateRef;

    private void Update()
    {
        if (EnemyAggroDistanceRef.IsAggro == false)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotOne.transform.position) < 2f && IsOnFirstPoint == false)//start point
        {
            IsOnFirstPoint = true;
            IsOnSecondPoint = false;
            IsWaitingOnPoint = true;
        }

        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotTwo.transform.position) < 2f && IsOnSecondPoint == false)
        {
           IsOnSecondPoint = true;
           IsOnFirstPoint = false;
           IsWaitingOnPoint = true;
        }


        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotOne.transform.position) >= 2f && !IsOnFirstPoint)
        {
            if(IsWaitingOnPoint)   
                StartCoroutine(PauseOnArrival());
            else if(IsWaitingOnPoint == false)
                EnemyGO.transform.position = Vector2.MoveTowards(EnemyGO.transform.position, PatrolSpotOne.transform.position, BaseEnemyRef.EnemySpeed * Time.deltaTime);
        }
        
        if(Vector2.Distance(transform.position, PatrolSpotTwo.transform.position) >= 2f && !IsOnSecondPoint)
        {
            if (IsWaitingOnPoint)
                StartCoroutine(PauseOnArrival());
            else if (IsWaitingOnPoint == false)
                EnemyGO.transform.position = Vector2.MoveTowards(EnemyGO.transform.position, PatrolSpotTwo.transform.position, BaseEnemyRef.EnemySpeed * Time.deltaTime);
        }
    }

    public IEnumerator PauseOnArrival()
    {
        Debug.Log("pause for a sec");
        yield return new WaitForSeconds(4f);
        Debug.Log("resume patrol");
        IsWaitingOnPoint = false;
    }

    public override State RunCurrentState()
    {
        if (EnemyAggroDistanceRef.IsAggro)
            return MovementStateRef;
        else
            return this;
    }
}
