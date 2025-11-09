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
        _maxTimeBtwAttacks = TimeBtwAttack;
        RestartTimerForAttacks();
    }

    private void Update()
    {
        DirectionalLooks.transform.position = AttackPos.position;//take this out when making art for sword swing

        if(Input.GetMouseButtonUp(0))
            IsLightAttack = true;
        else if(Input.GetMouseButton(0))
           IsHeavyAttack = true;

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButton(0) && CanMeleeAttackAgain)
        {
            StartCoroutine(WindUpAttack());
        }
        if(TimeBtwAttack <= 0f)
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
    void MeleeAttack()
    {
        Debug.Log("we are attacking");
        IsAttacking = true;

        Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);

        for (int i = 0; i < enemiesToDamges.Length; i++)
        {
            if(IsLightAttack)
                enemiesToDamges[i].GetComponent<BaseEnemy>().TakeDamage(PlayerLightAttkDamg);
            else if(IsHeavyAttack)
                enemiesToDamges[i].GetComponent<BaseEnemy>().TakeDamage(PlayerHeavyAttkDamg);
        }

        RestartTimerForAttacks();
    }
    public IEnumerator WindUpAttack()
    {
        Debug.Log("hello");
        yield return new WaitForSeconds(ChangingWindUpSpeed());
        Debug.Log("winding up for " + ChangingWindUpSpeed());
        MeleeAttack();
        IsAttacking = false;
    }
    float ChangingWindUpSpeed() => IsLightAttack ? WindUpSpeed = WindUpLightAttkSpd : WindUpSpeed = WindUpHeavyAttkSpd;
    void RestartTimerForAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange); 
    }
}
