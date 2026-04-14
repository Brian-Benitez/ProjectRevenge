using UnityEngine;

public class FinalPhaseUpgrades : MonoBehaviour
{
    [Header("Settings")]
    public bool IsInPhaseTwo = false;
    private float BossHalfHealth;
    [Header("All upgrades below will be ADDED to the bosses stats")]
    [Header("New Speed")]
    public float NewSpeed;
    [Header("New Melee stats")]
    public int NewMeleeDamg;
    public float NewMeleeTimeToAttack;
    [Header("New range stats")]
    public int NewRangeDam;
    public float NewAttackRange;
    public float NewRangeTimeToAttack;
    [Header("Scrpits")]
    public BaseEnemy BaseEnemyRef;
    public DKRangeAttack DKRangeAttackRef;
    public AttackState AttackStateRef;

    

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
        BaseEnemyRef.EnemySpeed += NewSpeed;
        BaseEnemyRef.EnemyDamage += NewMeleeDamg;
        AttackStateRef.TimeBtwAttack -= NewMeleeTimeToAttack;
        DKRangeAttackRef.DKRangeDamage += NewRangeDam;
        DKRangeAttackRef.RangeAttackRange += NewAttackRange;
        DKRangeAttackRef.TimeBtwAttack -= NewRangeTimeToAttack;
    }

    public void ChangeBossStatsToNormal()
    {
        BaseEnemyRef.EnemySpeed -= NewSpeed;
        BaseEnemyRef.EnemyDamage -= NewMeleeDamg;
        AttackStateRef.TimeBtwAttack += NewMeleeTimeToAttack;
        DKRangeAttackRef.DKRangeDamage -= NewRangeDam;
        DKRangeAttackRef.RangeAttackRange -= NewAttackRange;
        DKRangeAttackRef.TimeBtwAttack += NewRangeTimeToAttack;
    }
}
