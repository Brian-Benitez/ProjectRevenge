using UnityEngine;


public class GetWithinRangeAttackState : State
{
    [Header("Is Within Range")]
    public bool WithinRangeAttack = false;
    public float AttackRange;
    public float MeleeRange;
    public float StandByRange;
 
    //States below
    public RangeAttackLogicState ArcherAttackStateRef;

    [Header("Scripts")]
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public BaseEnemy EnemyStatsRef;
    public StunState StunStateRef;

    private void Update()
    {
        if(EnemyAggroDistanceRef.IsAggro)
        {
            ArcherMovement();
        }
    }

    void ArcherMovement()
    {
        if (StunStateRef.IsStunned)
            return;

        if (EnemyAggroDistanceRef.IsFightingPlayer)
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= AttackRange)
            {
                TurnOnWithinRangeBool();
            }

            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) >= AttackRange)//moving towards
            {
                TurnOffWithinRangeBool();
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemyStatsRef.EnemySpeed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= MeleeRange)//moving back
            {
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, -EnemyStatsRef.EnemySpeed / 2 * Time.deltaTime);
            }
        }
        else if (EnemyAggroDistanceRef.IsFightingPlayer == false)
        {
            if(Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= AttackRange)
            {
                EnemyTurnController.Instance.TryAddingEnemyToList(this.gameObject);
            }
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= StandByRange)//staying away but near because we arent fighting yet
            {
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, -EnemyStatsRef.EnemySpeed / 2 * Time.deltaTime);
                EnemyTurnController.Instance.RemoveEnemyFromList(this.gameObject);
            }
        }
    }
    public override State RunCurrentState()
    {
        if (WithinRangeAttack && EnemyStatsRef.EnemyType == BaseEnemy.TypeOfEnemy.Archer)
        {
            return ArcherAttackStateRef;
        }
        if(WithinRangeAttack && EnemyStatsRef.EnemyType == BaseEnemy.TypeOfEnemy.Wizard)
        {
            //return RangeAttackState;//change to wizard attack
        }
        return this;
    }
    //Helper functions-------------------------------------------------------->

    public void TurnOffWithinRangeBool() => WithinRangeAttack = false;
    public void TurnOnWithinRangeBool() => WithinRangeAttack = true;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, AttackRange);
        Gizmos.DrawWireSphere(this.gameObject.transform.position, MeleeRange);
        Gizmos.DrawWireSphere(this.gameObject.transform.position,StandByRange);
    }
}
