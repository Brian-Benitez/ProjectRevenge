using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator Animator;
    //public MovementState MovementState;
    public AttackState AttackStateRef;

    private void Update()
    {
        if (AttackStateRef.IsPlayingAttackAni)
            IsAttacking();
        else
            IsNotAttacking();
    }

    void IsAttacking()
    {
        Animator.SetBool("IsAttacking", true);
    }

    void IsNotAttacking()
    {
        Animator.SetBool("IsAttacking", false);
    }
}
