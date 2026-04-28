using UnityEngine;

public class BossStagesController : MonoBehaviour
{
    [Header("Settings")]
    public bool IsFinalStage = false;
    public bool HasInitalizedFinalStage = false;
    [Header("Upgrade Increments")]
    public int AmountOfAttkIncrease;
    public int AttackDamIncrease;
    public int RangeAttackDamIncrease;
    public float MovementSpeedIncrease;

    public BaseEnemy BossStats;
    public AttackState AttackStateRef;
    public DKRangeAttack DKRangeAttackRef;

    private void Update()
    {
        if(BossStats.EnemyHealth <= BossStats.MaxEnemyHealth / 2  && !IsFinalStage)
        {
            if(!HasInitalizedFinalStage)
            {
                IsFinalStage = true;
                BossFinalStageUpgrade();
                HasInitalizedFinalStage = true;
            }
        }
        else 
            IsFinalStage = false;
    }

    void BossFinalStageUpgrade()
    {
        Debug.Log("boss is in final stage");
        BossStats.EnemyDamage += AttackDamIncrease;
        BossStats.EnemySpeed += MovementSpeedIncrease;
        AttackStateRef.MaxAmountOfAttacks += AmountOfAttkIncrease;
        DKRangeAttackRef.DKRangeDamage += RangeAttackDamIncrease;
    }
    void BossRestatStats()
    {
        BossStats.EnemyDamage -= AttackDamIncrease;
        BossStats.EnemySpeed -= MovementSpeedIncrease;
        AttackStateRef.MaxAmountOfAttacks -= AmountOfAttkIncrease;
        DKRangeAttackRef.DKRangeDamage -= RangeAttackDamIncrease;
    }
}
