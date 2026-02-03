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
            Debug.Log("player can attack without worry");
            CanFightAgain = false;
        }
        else
        {
            Debug.Log("Go back to fighting player");
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
