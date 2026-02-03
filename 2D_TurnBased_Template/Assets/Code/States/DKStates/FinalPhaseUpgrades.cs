using UnityEngine;

public class FinalPhaseUpgrades : MonoBehaviour
{
    public bool IsInPhaseTwo = false;

    public float NewSpeed;
    public int NewDamg;
    public float NewMeleeTimeToAttack;

    public BaseEnemy BaseEnemyRef;
    public DKRangeAttack DKRangeAttackRef;
    public AttackState AttackStateRef;

    private void Update()
    {
        if(!IsInPhaseTwo)
        {
            if (CanGoToPhaseTwo())
                ChangeBossStats();
            IsInPhaseTwo = true;
        }
    }

    private bool CanGoToPhaseTwo()
    {
        if (BaseEnemyRef.EnemyHealth > BaseEnemyRef.EnemyHealth / 2)
        {
            Debug.Log("health is still bigger than half");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ChangeBossStats()
    {
        BaseEnemyRef.EnemySpeed = 3f;
        BaseEnemyRef.EnemyDamage = 6;
        AttackStateRef.TimeBtwAttack = 2;
        DKRangeAttackRef.DKRangeDamage = 2;
        DKRangeAttackRef.RangeAttackRange = 2;
        DKRangeAttackRef.TimeBtwAttack = 2;
    }

    public void ChangeBossStatsToNormal()
    {
        BaseEnemyRef.EnemySpeed = 3f;
        BaseEnemyRef.EnemyDamage = 6;
        AttackStateRef.TimeBtwAttack = 2;
        DKRangeAttackRef.DKRangeDamage = 2;
        DKRangeAttackRef.RangeAttackRange = 2;
        DKRangeAttackRef.TimeBtwAttack = 2;
    }
}
