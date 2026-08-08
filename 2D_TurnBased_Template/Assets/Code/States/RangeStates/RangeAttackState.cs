using System.Collections;
using UnityEngine;

public class RangeAttackState : State
{
    public float TimeBtwAttack;
    public float WindUpTime;

    public float ArrowSpeed;
    public GameObject EnemyCoreGO;
    public Rigidbody2D BulletPrefab;
    public Transform ShotPoint;
    public float RangeDistance;

    public bool CanRangeAttackAgain;
    public bool IsAttacking = false;
    public bool IsStillWithinRange = false;
    public bool LockedOnPlayer = true;
    public bool IsPlayingAnimation = true;

    public StunState StunStateRef;
    private IEnumerator _windUpArrowAttack;
   

    //Below is for enemies who are meduim level and up.
    [Header("Below is for enemies who are meduim level and up")]
    public Transform ShotPointTwo;
    public Transform ShotPointThree;

    GetWithinRangeAttackState GetWithinRangeAttackState;
    EnemyArcher _enemyArcherRef;
    private Rigidbody2D _bulletRB;
    private Rigidbody2D _bulletRBTwo;
    private Rigidbody2D _bulletRBThree;
    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        TimeBtwAttack = 0;
        GetWithinRangeAttackState = GetComponentInParent<GetWithinRangeAttackState>();
        _enemyArcherRef = GetComponentInParent<EnemyArcher>();
        _windUpArrowAttack = WindUpArrowAttack();
        BulletPrefab = _enemyArcherRef.EnemiesArrowRB;
    }


    private void Update()
    {
        if (StunStateRef.IsStunned)
            return;
        //This deals with rotating weapon below
        if(LockedOnPlayer)
        {
            Vector3 lookat = transform.InverseTransformPoint(PlayerController.Instance.Player.transform.position);
            float angle = Mathf.Atan2(lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
            transform.Rotate(0, 0, angle);
        }
        
        if (GetWithinRangeAttackState.WithinRangeAttack)
        {
            IsStillWithinRange = true;
            if (CanRangeAttackAgain)//check if the distance hits the minium then attack here
            {
                StartCoroutine(WindUpArrowAttack());
                RestartTimerForRangeAttacks();
            }

            if (TimeBtwAttack <= 0)
            {
                LockedOnPlayer = true;
                CanRangeAttackAgain = true;
                return;
            }
            else
            {
                TimeBtwAttack -= Time.deltaTime;
                CanRangeAttackAgain = false;
            }
        }
        else
            IsStillWithinRange = false;

    }

    void EnemyShootArrow()
    {
        if (_enemyArcherRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.LevelOne)
        {
            _bulletRB = Instantiate(BulletPrefab, ShotPoint.position, transform.rotation);
            _bulletRB.linearVelocity = _bulletRB.transform.up * ArrowSpeed;
        }
        if (_enemyArcherRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.LevelTwo)
        {
            _bulletRB = Instantiate(BulletPrefab, ShotPoint.position, transform.rotation);
            _bulletRB.linearVelocity = _bulletRB.transform.up * ArrowSpeed;

            _bulletRBTwo = Instantiate(BulletPrefab, ShotPointTwo.position, transform.rotation);
            _bulletRBTwo.linearVelocity = _bulletRB.transform.up * ArrowSpeed;

            _bulletRBThree = Instantiate(BulletPrefab, ShotPointThree.position, transform.rotation);
            _bulletRBThree.linearVelocity = _bulletRB.transform.up * ArrowSpeed;
        }
    }

    IEnumerator WindUpArrowAttack()
    {
        IsPlayingAnimation = true;
        yield return new WaitForSecondsRealtime(WindUpTime);
        LockedOnPlayer = false;
        EnemyShootArrow();
        IsPlayingAnimation = false;
    }

    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    public override State RunCurrentState()
    {
        if (StunStateRef.IsStunned)
        {
            StopCoroutine(_windUpArrowAttack);
        }
        if (!IsStillWithinRange)
        {
            GetWithinRangeAttackState.TurnOffWithinRangeBool();
            return GetWithinRangeAttackState;
        }
        else
        {
            IsAttacking = true;
        }

            return this;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ShotPoint.position, RangeDistance);
    }
}
