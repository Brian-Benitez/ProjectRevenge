using UnityEngine;

public class PatrolState : State
{
    public GameObject PatrolSpotOne;
    public GameObject PatrolSpotTwo;
    public GameObject EnemyGO;

    public bool DidMakeItToFirstPoint = false;

    public BaseEnemy BaseEnemyRef;
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public MovementState MovementStateRef;

    private void Update()
    {
        if(EnemyAggroDistanceRef.IsAggro == false)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotOne.transform.position) < 0.5f)
            DidMakeItToFirstPoint = true;

        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotTwo.transform.position) < 0.5f)
            DidMakeItToFirstPoint = false;

        if (Vector2.Distance(EnemyGO.transform.position, PatrolSpotOne.transform.position) > 0.5f && !DidMakeItToFirstPoint)
        {
            EnemyGO.transform.position = Vector2.MoveTowards(EnemyGO.transform.position, PatrolSpotOne.transform.position, BaseEnemyRef.EnemySpeed * Time.deltaTime);
        }
        

        
        if(Vector2.Distance(transform.position, PatrolSpotTwo.transform.position) > 0.5f && DidMakeItToFirstPoint)
        {
            EnemyGO.transform.position = Vector2.MoveTowards(EnemyGO.transform.position, PatrolSpotTwo.transform.position, BaseEnemyRef.EnemySpeed * Time.deltaTime);
        }
       
    }

    public override State RunCurrentState()
    {
        if (EnemyAggroDistanceRef.IsAggro)
            return MovementStateRef;
        else
            return this;
    }
}
