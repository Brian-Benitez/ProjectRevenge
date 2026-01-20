using UnityEngine;

public class ChaseState : State
{
    [Header("States")]
    AttackState AttackState;
    StunState StunState;
    BaseEnemy BaseEnemyRef;


    [Header("Floats")]
    public float MovementSpeed;
    public float MinimumDistance;
    public float DistanceFromPlayer;

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
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > MinimumDistance)
            {
                AttackState.WithinRange = false;// not yet in range
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, MovementSpeed * Time.deltaTime);
            }
            else
            {
                DistanceFromPlayer = Vector2.Distance(transform.position, PlayerController.Instance.Player.position);
                AttackState.WithinRange = true;
            }
        }
        else if (!EnemyAggroDistanceRef.IsAggro)// if u aint aggro, just chill
            return;
       
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
