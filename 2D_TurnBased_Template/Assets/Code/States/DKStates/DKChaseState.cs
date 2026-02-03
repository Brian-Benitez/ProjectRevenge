using UnityEngine;

public class DKChaseState : State
{
    private float MinimumDistanceFromPlayer = 5f;
    private float DistanceFromPlayer;
    private float PreferedRangeAttkDistance = 7f;

    public bool CanStartRangeAttack = false;

    [Header("Scripts")]
    public DKRangeAttack rangeAttack;
    public AttackState AttackState;
    public BaseEnemy BaseEnemyRef;


    private void Update()
    {
        if (rangeAttack.CanRangeAttack)
            return;

        //Debug.Log(DistanceFromPlayer = Vector2.Distance(transform.position, NPCController.Instance.Player.position));
        
        if(DistanceFromPlayer >= PreferedRangeAttkDistance && rangeAttack.CanRangeAttack)
            CanStartRangeAttack = true;  

        if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) > MinimumDistanceFromPlayer)
        {
            AttackState.WithinRange = false;// not yet in range
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, BaseEnemyRef.EnemySpeed * Time.deltaTime);
        }
        else
        {
            DistanceFromPlayer = Vector2.Distance(transform.position, PlayerController.Instance.Player.position);
            AttackState.WithinRange = true;
        }
    }

    public override State RunCurrentState()
    {
        if (AttackState.WithinRange)
        return AttackState;

        if (CanStartRangeAttack)
            return rangeAttack;

        return this;
    }
}
