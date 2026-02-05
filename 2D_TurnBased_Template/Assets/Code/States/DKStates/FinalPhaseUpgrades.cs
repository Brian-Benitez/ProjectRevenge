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

    public float BossHalfHealth;

    private void Start()
    {
        BossHalfHealth = BaseEnemyRef.EnemyHealth / 2;
    }

    private void Update()
    {
        if(CanGoToPhaseTwo())
        {
            if(!IsInPhaseTwo)
            {
                ChangeBossStats();
                Debug.Log("i changed");
                IsInPhaseTwo = true;
            }
           
        }
    }

    private bool CanGoToPhaseTwo()
    {
        if (BaseEnemyRef.EnemyHealth <= BossHalfHealth)
        {
            Debug.Log("health is still bigger than half");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ChangeBossStats()
    {
        Debug.Log("changed");
        BaseEnemyRef.EnemySpeed = NewSpeed;
        BaseEnemyRef.EnemyDamage = NewDamg;
        AttackStateRef.TimeBtwAttack = NewMeleeTimeToAttack;
        DKRangeAttackRef.DKRangeDamage = 3;
        DKRangeAttackRef.RangeAttackRange = 10;
        DKRangeAttackRef.TimeBtwAttack = 5f;
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
