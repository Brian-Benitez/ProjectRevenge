using UnityEngine;


public class GetWithinRangeAttackState : State
{
    [Header("Is Within Range")]
    public bool WithinRangeAttack = false;
    public float AttackRange;
    public float MeleeRange;
    [Header("Minimun distance to attack")]
    public float MinimunDistanceForRangeAttack;
 
    //States below
    RangeAttackState RangeAttackState;

    [Header("Scripts")]
    public EnemyAggroDistance EnemyAggroDistanceRef;
    public EnemyArcher EnemyArcherRef;

    private void Start()
    {
        RangeAttackState = GetComponentInChildren<RangeAttackState>();
    }

    private void Update()
    {
        if(EnemyAggroDistanceRef.IsAggro)
        {
            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= MinimunDistanceForRangeAttack)
            {
                if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) < AttackRange)
                {
                    TurnOnWithinRangeBool();
                }
            }

            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) <= MeleeRange)//moving back
            {
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, -EnemyArcherRef.EnemySpeed / 2 * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > AttackRange)//moving towards
            {
                transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, EnemyArcherRef.EnemySpeed * Time.deltaTime);
            }
        }
        else if(!EnemyAggroDistanceRef.IsAggro)
        {
            return;
        }
        
    }
    public override State RunCurrentState()
    {
        if (WithinRangeAttack && EnemyAggroDistanceRef.IsAggro)
        {
            return RangeAttackState;
        }
        return this;
    }
    //Helper functions-------------------------------------------------------->

    public void TurnOffWithinRangeBool() => WithinRangeAttack = false;
    public void TurnOnWithinRangeBool() => WithinRangeAttack = true;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, AttackRange);
        Gizmos.DrawWireSphere(this.gameObject.transform.position, MeleeRange);
    }
}
