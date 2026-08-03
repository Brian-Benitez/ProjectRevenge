using UnityEngine;

public class MovementState : State
{
    [Header("States")]
    AttackState AttackState;

    [Header("Floats")]
    public float FightingRange;
    public float StandByRange;
    public float StoppingDistance;
    public float DistanceFromPlayer;

    [Header("Scripts")]
    public EnemySwordsman EnemySwordsmanRef;
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public StunState StunStateRef;
    EnemyWeaponRotation _enemyWeaponRotationRef;

    private void Start()
    {
        AttackState = GetComponentInChildren<AttackState>();
        _enemyWeaponRotationRef = GetComponentInChildren<EnemyWeaponRotation>();
    }

    private void Update()
    {
        if (_enemyWeaponRotationRef.IsAttacking || AttackState.WithinRange || StunStateRef.IsStunned)
            return;

        if (EnemyAggroDistanceRef.IsAggro)
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= FightingRange)
            {
                EnemyAggroDistanceRef.IsFightingPlayer = true;
            }
            ChangeStoppingDistance();
            MoveBasedOnPriority();
        }
        else if (!EnemyAggroDistanceRef.IsAggro)
            return;
       
    }
    //changing distance code
    void ChangeStoppingDistance()
    {
        if(EnemyAggroDistanceRef.IsAggro && EnemyAggroDistanceRef.IsFightingPlayer)
        {
            StoppingDistance = FightingRange;
        }
        else if(EnemyAggroDistanceRef.IsAggro && !EnemyAggroDistanceRef.IsFightingPlayer)
        {
            StoppingDistance = StandByRange;
        }
    }
    /// <summary>
    /// movement code
    /// </summary>
    void MoveBasedOnPriority()
    {
        if (EnemyAggroDistanceRef.IsFightingPlayer || Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= FightingRange)
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > FightingRange)
            {
                AttackState.WithinRange = false;
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemySwordsmanRef.EnemySpeed * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= FightingRange)
            {
                AttackState.WithinRange = true;
                EnemyAggroDistanceRef.IsFightingPlayer = true;//this is for when a aggro enemy is far away from player and one enemy is closer to fight player
            }
        }  
        else if(Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > FightingRange)
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= StandByRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, -EnemySwordsmanRef.EnemySpeed / 2 * Time.deltaTime);
                //get away from player unless your right next to them or circumstances changes
            }
        }
            
        DistanceFromPlayer = Vector2.Distance(transform.position, PlayerController.Instance.Player.position);
    }

    public override State RunCurrentState()
    {
        if (AttackState.WithinRange)
            return AttackState;

        return this;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FightingRange);
        Gizmos.DrawWireSphere(transform.position, StandByRange);
    }

}
