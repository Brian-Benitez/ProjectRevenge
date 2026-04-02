using UnityEngine;

public class MovementState : State
{
    [Header("States")]
    AttackState AttackState;
    StunState StunState;
    BaseEnemy BaseEnemyRef;


    [Header("Floats")]
    public float FightingRange;
    public float StandByRange;
    public float StoppingDistance;
    public float DistanceFromPlayer;
    public bool IsAThreat = false;

    [Header("Scripts")]
    public EnemySwordsman EnemySwordsmanRef;
    public EnemyAggroDistance EnemyAggroDistanceRef;
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
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= FightingRange)
            {
                IsAThreat = true;
            }
        }
        else if (!EnemyAggroDistanceRef.IsAggro)
            return;
       
    }
    //changing distance code
    void ChangeStoppingDistannce()
    {
        if(EnemyTurnController.Instance.IsThereAnOpenSlot && EnemyAggroDistanceRef.IsAggro && IsAThreat)
        {
            StoppingDistance = FightingRange;
        }
        else if(EnemyTurnController.Instance.IsThereAnOpenSlot == false && EnemyAggroDistanceRef.IsAggro && !IsAThreat)
        {
            StoppingDistance = StandByRange;
        }
    }
    /// <summary>
    /// movement code
    /// </summary>
    void MoveBasedOnPriority()
    {
        if (EnemyTurnController.Instance.IsThereAnOpenSlot == true || IsAThreat)
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > FightingRange || IsAThreat)
            {
                AttackState.WithinRange = false;
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemySwordsmanRef.EnemySpeed * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= FightingRange)
            {
                AttackState.WithinRange = true;
                if(EnemyTurnController.Instance.IsEnemyInList(this.gameObject) == false)
                    EnemyTurnController.Instance.AddEnemyToList(this.gameObject);

                IsAThreat = true;
            }
        }  
        else
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= StandByRange && EnemyTurnController.Instance.IsEnemyInList(this.gameObject) == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, -EnemySwordsmanRef.EnemySpeed * Time.deltaTime);
            }
        }

        DistanceFromPlayer = Vector2.Distance(transform.position, PlayerController.Instance.Player.position);
    }

    public override State RunCurrentState()
    {
        if (BaseEnemyRef.IsStunned)
            return StunState;

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
