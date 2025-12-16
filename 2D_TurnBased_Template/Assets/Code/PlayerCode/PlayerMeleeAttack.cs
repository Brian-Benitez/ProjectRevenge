using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Transforms")]
    public Transform AttackPos;
    public Transform DirectionalLooks;
    [Header("----------Stats----------")]
    [Header("Floats")]
    public float AttackRange;

    [Header("Windup Stats")]
    public float WindUpSpeed;
    public float WindUpLightAttkSpd;

    [Header("Heavy Windup Stats")]
    public float HeavyWindUpSpeed;
    public float MaxHeavyWindUpSpeed;

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
    public bool ChangedValues = false;  

    //private vars
    private float _maxTimeBtwAttacks;
    private float _holdTime = 0f;
    private float _maxHoldTimeForHeavyAttk = 0.2f;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
        _maxTimeBtwAttacks = WindUpSpeed;
        RestartTimerForAttacks();
    }

    private void Update()
    {
        DirectionalLooks.transform.position = AttackPos.position;//idk why this gets paused when i stop moving player

        if (Input.GetMouseButtonDown(0) && CanMeleeAttackAgain)
        {
            Debug.Log("light kill");
            Hit(PlayerLightAttkDamg);
            _playerMovement.UnSlowPlayer();
        }

        if (Input.GetMouseButton(0))
        {
            _holdTime += Time.deltaTime;
            
            if (_holdTime >= _maxHoldTimeForHeavyAttk)
            {
                _playerMovement.SlowPlayer();
                CanMeleeAttackAgain = false;

                if(HeavyWindUpSpeed >= MaxHeavyWindUpSpeed)
                {
                    IsHeavyAttack = true;
                    CanMeleeAttackAgain = true;
                }
                else
                {
                    HeavyWindUpSpeed += Time.deltaTime;//double check all this
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && IsHeavyAttack && CanMeleeAttackAgain)
        {
            Debug.Log("heavy kill");
            Hit(PlayerHeavyAttkDamg);
            _playerMovement.UnSlowPlayer();
        }

        if (WindUpSpeed <= 0f)
        {
            CanMeleeAttackAgain = true;
            IsAttacking = false;
            return;
        }
        else
        {
            WindUpSpeed -= Time.deltaTime;
            CanMeleeAttackAgain = false;
        }
    }

    void Hit(int dam)
    {
        IsAttacking = true;
        Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);
        for (int i = 0; i < enemiesToDamges.Length; i++)
        {
            enemiesToDamges[i].GetComponent<BaseEnemy>().TakeDamage(dam);
        }
        RestartTimerForAttacks();
        RestartMeleeBools();
    }
    void RestartTimerForAttacks() => WindUpSpeed = _maxTimeBtwAttacks;

    void RestartMeleeBools()
    {
        IsHeavyAttack = false;
        IsLightAttack = false;
        ChangedValues = false;
        _holdTime = 0f;
        HeavyWindUpSpeed = 0f;  
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
