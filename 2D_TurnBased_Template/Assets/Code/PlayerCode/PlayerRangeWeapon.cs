using UnityEngine;

public class PlayerRangeWeapon : MonoBehaviour
{
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;

    public bool CanRangeAttackAgain;

    private float _maxTimeBtwAttacks;
    public PlayerStunnedState PlayerStunnedStateRef;
    private PlayerMovement PlayerMovementRef;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        PlayerMovementRef = GetComponentInParent<PlayerMovement>();
    }


    private void Update()
    {
        if (PlayerMovementRef.IsDashing || PlayerStunnedStateRef.IsPlayerStuuned)
            return;

        if(Input.GetMouseButton(1) && Input.GetMouseButtonDown(0) && PlayerAmmoController.Instance.DoesPlayerHaveAmmo() && CanRangeAttackAgain)
        {
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

    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

}
