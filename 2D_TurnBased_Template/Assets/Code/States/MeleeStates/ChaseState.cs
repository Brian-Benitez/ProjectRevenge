using UnityEngine;

public class ChaseState : State
{
    [Header("States")]
    AttackState AttackState;
    StunState StunState;
    BaseEnemy BaseEnemyRef;


    [Header("Floats")]
    public float AttackingRange;
    public float MinimumDistance;
    public float StoppingDistance;
    public float DistanceFromPlayer;

    [Header("Scripts")]
    public EnemySwordsman EnemySwordsmanRef;
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public DetermineEnemyPriority DetermineEnemyPriorityRef;
    EnemyWeaponRotation _enemyWeaponRotationRef;

    private void Start()
    {
        AttackState = GetComponentInChildren<AttackState>();
        StunState = GetComponent<StunState>();
        BaseEnemyRef = GetComponent<BaseEnemy>();
        _enemyWeaponRotationRef = GetComponentInChildren<EnemyWeaponRotation>();
    }

    private void Update()
    {
        if (_enemyWeaponRotationRef.IsAttacking)
            return;

        if (EnemyAggroDistanceRef.IsAggro)
        {
            ChangeStoppingDistannce();
            MoveBasedOnPriority();
        }
        else if (!EnemyAggroDistanceRef.IsAggro)// if u aint aggro, just chill
            return;
       
    }
    //changing distance code
    void ChangeStoppingDistannce()
    {
        if(DetermineEnemyPriorityRef.EnemyPriorty == 1)
        {
            StoppingDistance = DetermineEnemyPriorityRef.OnePriorityDistance;
        }
        else if(DetermineEnemyPriorityRef.EnemyPriorty == 2)
        {
            StoppingDistance = DetermineEnemyPriorityRef.TwoPriorityDistance;
        }
    }
    /// <summary>
    /// movement code
    /// </summary>
    void MoveBasedOnPriority()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > AttackingRange && DetermineEnemyPriorityRef.EnemyPriorty == 1)
        {
            AttackState.WithinRange = false;
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemySwordsmanRef.EnemySpeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= AttackingRange)
        {
            AttackState.WithinRange = true;
        }
        //make another check like line 62 but for priority 2 but move slow to the border of priorty 1
    }

    public override State RunCurrentState()
    {
        if (BaseEnemyRef.IsStunned)
            return StunState;

        if (AttackState.WithinRange)
            return AttackState;

        return this;
    }

}
