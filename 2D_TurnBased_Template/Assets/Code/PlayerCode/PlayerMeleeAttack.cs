using System.Collections;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Transforms")]
    public Transform AttackPos;
    public Transform HerosSword;
    public Transform DirectionalLooks;
    [Header("----------Stats----------")]
    [Header("Floats")]
    public float AttackRange;
    public float TimeBtwAttack;

    [Header("Windup Stats")]
    public float WindUpSpeed;
    public float WindUpLightAttkSpd;
    public float WindUpHeavyAttkSpd;

    [Header("Player attk damg")]
    public int PlayerLightAttkDamg;
    public int PlayerHeavyAttkDamg;

    [Header("Type Of Attack")]
    public bool IsLightAttack = false;
    public bool IsHeavyAttack = false;

    [Header("LayerMasks")]
    public LayerMask WhatIsEnemies;

    [Header("Booleans")]
    public bool CanMeleeAttackAgain = false;
    public bool IsAttacking = false;

    //private vars
    private float _maxTimeBtwAttacks;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
        //_knockForwardFeedBack = GetComponent<KnockForwardFeedBack>();
        _maxTimeBtwAttacks = TimeBtwAttack;
        RestartTimerForAttacks();
    }

    private void Update()
    {
        DirectionalLooks.transform.position = AttackPos.position;//take this out when making art for sword swing

        if (Input.GetMouseButtonDown(0) && CanMeleeAttackAgain)
        {
            IsAttacking = true;
            //_knockForwardFeedBack.PlayFeedBack(DirectionalLooks.gameObject);
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);
            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                enemiesToDamges[i].GetComponent<BaseEnemy>().TakeDamage(PlayerLightAttkDamg);
            }
            RestartTimerForAttacks();
        }
        if (TimeBtwAttack <= 0f)
        {
            CanMeleeAttackAgain = true;
            IsAttacking = false;
            return;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            CanMeleeAttackAgain = false;
        }

    }
    void RestartTimerForAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
