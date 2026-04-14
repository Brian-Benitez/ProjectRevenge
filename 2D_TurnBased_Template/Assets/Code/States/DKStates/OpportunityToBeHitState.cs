using UnityEngine;

public class OpportunityToBeHitState : State
{
    [Header("Stats")]
    public int TimesBossAttacked = 0;
    public bool CanFightAgain = false;

    public AttackState AttackState;
    public DKChaseState DKChaseState;

    private void Update()
    {
        if(AttackState.TimeBtwAttack > 0f)
        {
            CanFightAgain = false;
        }
        else
        {
            CanFightAgain = true;
        }
    }


    public override State RunCurrentState()
    {
        if (CanFightAgain)
            return DKChaseState;
        else
            return this;
    }
}
