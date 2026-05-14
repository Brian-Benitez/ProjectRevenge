using UnityEngine;

public class PlayerRangeWeapon : MonoBehaviour
{
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;
    public bool CanRangeAttackAgain;

    [Header("For upgrades below")]
    public bool IsUsingShotgunPerk = false;
    public Transform ShotPointTwo;
    public Transform ShotPointThree;
    public float LoweredRangeDistance;

    private float _maxTimeBtwAttacks;
    private PlayerMovement PlayerMovementRef;
    private Projectile ProjectileRef;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        ProjectileRef = Projectile.GetComponent<Projectile>();
        ProjectileRef.DistanceOfProjectile = ProjectileRef.MaxDistance;
        ProjectileRef.LifeTimeOfProjectile = ProjectileRef.MaxDistance;
        PlayerMovementRef = GetComponentInParent<PlayerMovement>();
    }


    private void Update()
    {
        if (PlayerMovementRef.IsDashing)
            return;

        if(Input.GetMouseButton(1) && Input.GetMouseButtonDown(0) && PlayerAmmoController.Instance.DoesPlayerHaveAmmo() && CanRangeAttackAgain)
        {
            if(IsUsingShotgunPerk)
            {
                Instantiate(Projectile, ShotPoint.position, transform.rotation);
                Instantiate(Projectile, ShotPointTwo.position, transform.rotation);
                Instantiate(Projectile, ShotPointThree.position, transform.rotation);
            }
            else
                Instantiate(Projectile, ShotPoint.position, transform.rotation);

            PlayerAmmoController.Instance.RemoveAmmo();
            RestartTimerForRangeAttacks();
        }

        if(TimeBtwAttack <= 0)
        {
            CanRangeAttackAgain = true;
            return;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            CanRangeAttackAgain = false;
        }

    }

    public void ChangeArrowsDurations()
    {
        Projectile.GetComponent<Projectile>().LifeTimeOfProjectile -= Mathf.Clamp(LoweredRangeDistance, 0, 9);
        Projectile.GetComponent<Projectile>().DistanceOfProjectile -= Mathf.Clamp(LoweredRangeDistance, 0, 9);
    }
    public void NormalArrowDurations()
    {
        IsUsingShotgunPerk = false;
        Projectile.GetComponent<Projectile>().LifeTimeOfProjectile += Mathf.Clamp(LoweredRangeDistance, 0, 9);
        Projectile.GetComponent<Projectile>().DistanceOfProjectile += Mathf.Clamp(LoweredRangeDistance, 0, 9);
    }
    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

}
