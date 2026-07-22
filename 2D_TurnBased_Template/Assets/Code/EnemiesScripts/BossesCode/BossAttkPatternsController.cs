using UnityEngine;

public class BossAttkPatternsController : MonoBehaviour
{
    public float AttkCooldown;
    public float MaxCooldown;
    public StunState StunStateRef;
    private void Update()
    {
        if (AttkCooldown >= MaxCooldown)
            CanBeAttacked();
        else
            CannotBeAttacked();
        AttkCooldown++;
    }

    public void CanBeAttacked() => StunStateRef.InstanteStun = true;
    public void CannotBeAttacked() => StunStateRef.InstanteStun = false;
}
