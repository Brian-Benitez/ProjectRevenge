using UnityEngine;

public class PatrolState : State
{
    public GameObject PatrolSpotOne;
    public GameObject PatrolSpotTwo;
    public GameObject EnemyGO;

    public bool IsOnFirstPoint = false;
    public bool IsOnSecondPoint = false;    

    public BaseEnemy BaseEnemyRef;
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public PausingState PausingState;

    [Header("Swordmans Code")]
    public MovementState MovementStateRef;

    [Header("Archer Code")]
    public GetWithinRangeAttackState GetWithinRangeAttackStateRef;


    private void Update()
    {
        if (EnemyAggroDistanceRef.IsAggro == false && PausingState.TimerIsDone)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotOne.transform.position) < 2f && IsOnFirstPoint == false)
        {
           IsOnFirstPoint = true;
           IsOnSecondPoint = false;
            PausingState.TimerIsDone = false;
        }

        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotTwo.transform.position) < 2f && IsOnSecondPoint == false)
        {
           IsOnSecondPoint = true;
           IsOnFirstPoint = false;
            PausingState.TimerIsDone = false;
        }


        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotOne.transform.position) >= 2f && !IsOnFirstPoint)
        {
            EnemyGO.transform.position = Vector2.MoveTowards(EnemyGO.transform.position, PatrolSpotOne.transform.position, BaseEnemyRef.PatrolSpeed * Time.deltaTime);
            
        }
        
        if(Vector2.Distance(transform.position, PatrolSpotTwo.transform.position) >= 2f && !IsOnSecondPoint)
        {
            EnemyGO.transform.position = Vector2.MoveTowards(EnemyGO.transform.position, PatrolSpotTwo.transform.position, BaseEnemyRef.PatrolSpeed * Time.deltaTime);
            
        }
    }

 

    public override State RunCurrentState()
    {
        if (EnemyAggroDistanceRef.IsAggro)
        {
            if(BaseEnemyRef.EnemyType == BaseEnemy.TypeOfEnemy.Swordsman)
                return MovementStateRef;
            if (BaseEnemyRef.EnemyType == BaseEnemy.TypeOfEnemy.Archer)
                return GetWithinRangeAttackStateRef;
        }   
        else if (IsOnFirstPoint || IsOnSecondPoint)
            return PausingState;

        return this;
    }
}
