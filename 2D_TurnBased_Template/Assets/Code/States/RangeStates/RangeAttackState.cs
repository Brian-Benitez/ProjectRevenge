using UnityEngine;

public class RangeAttackState : State
{
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;
    //Below is for enemies who are meduim level and up.
    [Header("Below is for enemies who are meduim level and up")]
    public Transform ShotPointTwo;
    public Transform ShotPointThree;

    public bool CanRangeAttackAgain;
    public bool IsAttacking = false;
    public bool IsStillWithinRange = false;
    public bool LockedOnPlayer = true;

    GetWithinRangeAttackState GetWithinRangeAttackState;
    EnemyArcher _enemyArcherRef;

    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        GetWithinRangeAttackState = GetComponentInParent<GetWithinRangeAttackState>();
        _enemyArcherRef = GetComponentInParent<EnemyArcher>();
    }


    private void Update()
    {
        //This deals with rotating weapon below
        if(LockedOnPlayer)
        {
            Vector3 lookat = transform.InverseTransformPoint(PlayerController.Instance.Player.transform.position);
            float angle = Mathf.Atan2(lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
            transform.Rotate(0, 0, angle);
        }

        if (GetWithinRangeAttackState.DistanceFromTarget < GetWithinRangeAttackState.MinimunDistanceForRangeAttack)
        {
            IsStillWithinRange = true;
            if (CanRangeAttackAgain)//check if the distance hits the minium then attack here
            {
                LockedOnPlayer = false;
                if(_enemyArcherRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Easy)
                {
                    Instantiate(Projectile, ShotPoint.position, transform.rotation);
                }
                if(_enemyArcherRef.EnemyDifficulty == BaseEnemy.LevelOfEnemy.Medium)
                {
                    Instantiate(Projectile, ShotPoint.position, transform.rotation);
                    Instantiate(Projectile, ShotPointTwo.position, transform.rotation);
                    Instantiate(Projectile, ShotPointThree.position, transform.rotation);
                }
                
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

    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    public override State RunCurrentState()
    {
        if (!IsStillWithinRange)
        {
            Debug.Log("get back ti within range!");
            GetWithinRangeAttackState.TurnOffWithinRangeBool();
            return GetWithinRangeAttackState;
        }
        if (!IsAttacking)
        {
            GetWithinRangeAttackState.TurnOffWithinRangeBool();
        }
        else
        {
            IsAttacking = true;
            Debug.Log("still attaking "+ IsAttacking);
        }

            return this;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ShotPoint.position, 8f);
    }
}
