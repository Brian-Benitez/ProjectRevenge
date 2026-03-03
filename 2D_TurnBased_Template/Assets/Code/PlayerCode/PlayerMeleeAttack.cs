using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Spiecal stats")]
    public KeyCode SpecialKey;
    public Transform SpeicalPos;
    public float SpeicalRange;

    [Header("Transforms")]
    public Transform AttackPos;
    public Transform DirectionalLooks;
    [Header("----------Stats----------")]
    [Header("Floats")]
    public float AttackRange;

    [Header("Windup Stats")]
    public float WindUpSpeed;

    [Header("Heavy Windup Stats")]
    public float HeavyWindUpSpeed;
    public float MaxHeavyWindUpSpeed;

    [Header("Player attk damg")]
    public int PlayerLightAttkDamg;
    public int PlayerHeavyAttkDamg;
    public int PlayerSpecialDamg;

    [Header("Type Of Attack")]
    public bool IsLightAttack = false;
    public bool IsHeavyAttack = false;
    public bool IsSpecialAttack = false;

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
            Hit(PlayerLightAttkDamg, AttackPos, AttackRange, WhatIsEnemies);
            _playerMovement.UnSlowPlayer();
        }

        if(Input.GetKeyDown(SpecialKey) && CanMeleeAttackAgain)
        {
            Debug.Log("Special attack");
            IsSpecialAttack = true;
            Hit(PlayerSpecialDamg, SpeicalPos, SpeicalRange, WhatIsEnemies);
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
            Hit(PlayerHeavyAttkDamg, AttackPos, AttackRange, WhatIsEnemies);
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

    void Hit(int dam, Transform pos, float range, LayerMask enemy)
    {
        IsAttacking = true;
        
        Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(pos.position, range, enemy);

        for (int i = 0; i < enemiesToDamges.Length; i++)
        {
            if (enemiesToDamges[i].GetComponent<ObjectHittableTrigger>() != null)
            {
                enemiesToDamges[i].GetComponent<ObjectHittableTrigger>().TurnIsOnOn();
                Debug.Log("turn on bool");
            }
            if(enemiesToDamges[i].GetComponent<BaseEnemy>() != null)
            {
                enemiesToDamges[i].GetComponent<BaseEnemy>().TakeDamage(dam);
            }
            if (enemiesToDamges[i].CompareTag("EnemyShield"))
            {
                enemiesToDamges[i].GetComponent<EnemyShield>().ShieldTakeDamage(dam);
            }
        }
        RestartTimerForAttacks();
        RestartMeleeBools();
    }
    void RestartTimerForAttacks() => WindUpSpeed = _maxTimeBtwAttacks;

    void RestartMeleeBools()
    {
        IsHeavyAttack = false;
        IsSpecialAttack = false;
        IsLightAttack = false;
        ChangedValues = false;
        _holdTime = 0f;
        HeavyWindUpSpeed = 0f;  
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
        Gizmos.DrawWireSphere(SpeicalPos.position, SpeicalRange);
    }
}
