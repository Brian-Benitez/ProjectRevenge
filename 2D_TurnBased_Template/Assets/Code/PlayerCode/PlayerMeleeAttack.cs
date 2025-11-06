using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Transforms")]
    public Transform AttackPos;
    public Transform HerosSword;
    public Transform DirectionalLooks;

    [Header("Floats")]
    public float AttackRange;
    public float TimeBtwAttack;

    [Header("Ints")]
    public int PlayerDamage;

    [Header("LayerMasks")]
    public LayerMask WhatIsEnemies;

    [Header("Booleans")]
    public bool CanMeleeAttackAgain = false;

    public bool IsAttacking = false;

    //[SerializeField]
    private float _maxTimeBtwAttacks;
    private PlayerMovement _playerMovement;
    public KnockForwardFeedBack _knockForwardFeedBack;

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

        if (Input.GetMouseButtonUp(0) && CanMeleeAttackAgain)
        {
            IsAttacking = true;
            //_knockForwardFeedBack.PlayFeedBack(DirectionalLooks.gameObject);
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);
            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                enemiesToDamges[i].GetComponent<BaseEnemy>().TakeDamage(PlayerDamage);
            }
            RestartTimerForAttacks();
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
    void RestartTimerForAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange); 
    }
}
