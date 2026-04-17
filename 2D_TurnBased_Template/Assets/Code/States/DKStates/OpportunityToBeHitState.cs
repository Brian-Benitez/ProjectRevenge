using UnityEngine;

public class OpportunityToBeHitState : State
{//DELETEE ALL THIS
    [Header("Stats")]
    public int TimesBossAttacked = 0;
    public bool CanFightAgain = false;

    public AttackState AttackState;
    public DKChaseState DKChaseState;

    private void Update()
    {
        
    }


    public override State RunCurrentState()
    {
        if (CanFightAgain)
            return DKChaseState;
        else
            return this;
    }
}
