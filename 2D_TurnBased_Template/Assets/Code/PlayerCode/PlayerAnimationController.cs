using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator PlayerAnimator;

    public PlayerMeleeAttack PlayerMeleeAttackRef;
    public PlayerMovement PlayerMovementRef;


    private void Update()
    {
        if (PlayerMeleeAttackRef.IsAttacking)
            IsAttacking();
        else
            IsNotAttacking();
        if (PlayerMovementRef.IsDashing)
            IsDashing();
        else
            IsNotDashing();
    }

    //Walking animations bools
    public void IsMoving() => PlayerAnimator.SetBool("IsMoving", true);
    public void IsNotMoving() => PlayerAnimator.SetBool("IsMoving", false);

    //Attacking animations bools
    public void IsAttacking()
    {
        PlayerAnimator.SetBool("IsAttacking", true);
    }
    public void IsNotAttacking()
    {
        PlayerAnimator.SetBool("IsAttacking", false);
    }

    public void IsDashing() => PlayerAnimator.SetBool("IsDashing", true);
    public void IsNotDashing() => PlayerAnimator.SetBool("IsDashing", false);
}
