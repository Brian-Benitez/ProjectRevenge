using UnityEngine;

public class BossVunerableState : State
{
    public float AttkCooldown;
    public float MaxCooldown;
    private bool _startCountdown = false;
    public StunState StunStateRef;
    public AttackState AttackStateRef;

    private void Update()
    {
        if(_startCountdown)
            AttkCooldown += Time.deltaTime;
    }

    public override State RunCurrentState()
    {
        _startCountdown = true;
        if (AttkCooldown >= MaxCooldown)
        {
            StunStateRef.InstanteStun = false;
            AttkCooldown = 0;
            _startCountdown = false;
            return AttackStateRef;
        }
        else
        {
            StunStateRef.InstanteStun = true;
            return this;
        } 
    }
}
