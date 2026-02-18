
using System.Collections;
using UnityEngine;

public class AttackState : State//rename this to EnemyAttackState
{
    [Header("Test demo")]
    public GameObject WindingUpIcon;
    public GameObject AttackingIcon;
    public bool IsRunning = false;

    [Header("Melee pos")]
    public Transform MeleePos;

    [Header("Enemys attack range and T.T.A")]
    public float AttackRange;
    public float TimeBtwAttack;
    public float WindUpTimeForMelee;

    [Header("Bools Conditions to attack")]
    public bool CanHitAgain = true;
    public bool WithinRange = false;

    [Header("Layermasks for what can be hit")]
    public LayerMask WhatisHittable;

    public bool AttackMissedPlayer = false;

    private EnemySwordsman EnemySwordsmanRef;
    //States ref here
    MovementState ChaseState;
    StunState StunState;
    BlockAndMoveState BlockAndMoveState;
    OpportunityToBeHitState OpportunityToBeHitState;
    EnemyWeaponRotation _enemyWeaponRotationRef;


    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        EnemySwordsmanRef = gameObject.GetComponentInParent<EnemySwordsman>();
        ChaseState = GetComponentInParent<MovementState>();
        _enemyWeaponRotationRef = GetComponentInParent<EnemyWeaponRotation>();

        if (EnemySwordsmanRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Medium)
        {
            BlockAndMoveState = GetComponentInParent<BlockAndMoveState>();
        }

        if (EnemySwordsmanRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Boss)
        {
            OpportunityToBeHitState = GetComponent<OpportunityToBeHitState>();
        }
    }

    void Update()
    {
        if (CanHitAgain && WithinRange && !IsRunning)
        {
            _enemyWeaponRotationRef.IsAttacking = true;
            StartCoroutine(WindUpAttack());
            RestartTimerForAttacks();
        }

        if (TimeBtwAttack <= 0f)
        {
            WindingUpIcon.SetActive(true);
            CanHitAgain = true;
            return;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            CanHitAgain = false;
        }
    }

    void MeleeAttack()
    {
        Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(MeleePos.position, AttackRange, WhatisHittable);

        if (enemiesToDamges.Length == 0)
        {
            Debug.Log("i hit no one:(");
            AttackMissedPlayer = true;
        }
        else
            AttackMissedPlayer = false;

        for (int i = 0; i < enemiesToDamges.Length; i++)
        {
            if (enemiesToDamges[i].CompareTag("Shield"))
            {
                Debug.Log("Hit shield!");
                ShieldController.instance.ShieldHealth -= EnemySwordsmanRef.EnemyDamage;
            }

            if (enemiesToDamges[i].CompareTag("Player"))
            {
                enemiesToDamges[i].GetComponent<BaseCharacter>().TakeDamage(EnemySwordsmanRef.EnemyDamage);
                Debug.Log("Enemy hit " + enemiesToDamges[i].gameObject.name + "for " + EnemySwordsmanRef.EnemyDamage);
            }
        }

        if (EnemySwordsmanRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Medium)
        {
            BlockAndMoveState.RollingToBlock();
        }
    }
    public IEnumerator WindUpAttack()
    {
        IsRunning = true;
        Debug.Log("Winding up attack " + WindUpTimeForMelee + " Seconds");
        yield return new WaitForSecondsRealtime(WindUpTimeForMelee);
        Debug.Log("Winding up attack done");
        MeleeAttack();
        WindingUpIcon.SetActive(false);
        AttackingIcon.SetActive(true);
        _enemyWeaponRotationRef.IsAttacking = false;
        IsRunning = false;
    }

    public override State RunCurrentState()
    {
        if (EnemySwordsmanRef.IsStunned)
            return StunState;

        if (EnemySwordsmanRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Medium && BlockAndMoveState.CanBlock)
        {
            //block and move back state

            return BlockAndMoveState;
        }
        if (EnemySwordsmanRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Hard)
        {
            //do something
        }
        if (EnemySwordsmanRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Boss)
            return OpportunityToBeHitState;

        if (AttackMissedPlayer == true)
        {
            Debug.Log("go here");
            //ChaseState.RestartDistance();
            RestartEnemy();
            return ChaseState;
        }

        return this;
    }

    public void RestartEnemy()
    {
        AttackMissedPlayer = false;
        WithinRange = false;
        IsRunning = false;
        _enemyWeaponRotationRef.IsAttacking = false;
    }

    void RestartTimerForAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    //----------------------------------------------------Debug--stuff--------------------------------------------------------------------->
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(MeleePos.position, AttackRange);
    }
}
