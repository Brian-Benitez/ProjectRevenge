using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator Animator;
    //public MovementState MovementState;
    public BaseEnemy BaseEnemy;
    public AttackState AttackStateRef;
    public RangeAttackState RangeAttackState;

    private void Update()
    {
        if(BaseEnemy.EnemyType == BaseEnemy.TypeOfEnemy.Archer)
        {
            if (RangeAttackState.IsPlayingAnimation == true)
                IsAttacking();
            else
                IsNotAttacking();
        }
        if(BaseEnemy.EnemyType == BaseEnemy.TypeOfEnemy.Swordsman)
        {
            if (AttackStateRef.IsPlayingAttackAni)
                IsAttacking();
            else
                IsNotAttacking();
        }
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
