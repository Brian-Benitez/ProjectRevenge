using UnityEngine;

public class MovementState : State
{
    [Header("States")]
    AttackState AttackState;
    StunState StunState;
    BaseEnemy BaseEnemyRef;


    [Header("Floats")]
    public float AttackingRange;
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
        else if (!EnemyAggroDistanceRef.IsAggro)
            return;
       
    }
    //changing distance code
    void ChangeStoppingDistannce()
    {
        if(DetermineEnemyPriorityRef.IsFullAggro)
        {
            StoppingDistance = DetermineEnemyPriorityRef.FullAggroStopDistance;
        }
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
        //below is shit, i know this, i will work on it later. Needs to be fun first the  optimized
        if(Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > AttackingRange && DetermineEnemyPriorityRef.IsFullAggro)
        {
            AttackState.WithinRange = false;
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemySwordsmanRef.EnemySpeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > AttackingRange && DetermineEnemyPriorityRef.EnemyPriorty == 1)
        {
            AttackState.WithinRange = false;
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemySwordsmanRef.EnemySpeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= AttackingRange)
        {
            AttackState.WithinRange = true;
        }
        
        //priority 2 enemies here
        if(DistanceFromPlayer <= StoppingDistance && DetermineEnemyPriorityRef.EnemyPriorty == 2)
        {
            Debug.Log("wait for your turn");
        }
        if (DistanceFromPlayer > StoppingDistance && DetermineEnemyPriorityRef.EnemyPriorty == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemySwordsmanRef.EnemySpeed * Time.deltaTime);
        }

        DistanceFromPlayer = Vector2.Distance(transform.position, PlayerController.Instance.Player.position);
        Debug.Log(DistanceFromPlayer);
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
