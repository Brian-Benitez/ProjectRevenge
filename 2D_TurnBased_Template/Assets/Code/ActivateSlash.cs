using UnityEngine;

public class ActivateSlash : MonoBehaviour
{
    public Animator SlashEffect;
    public PlayerMeleeAttack PlayerMeleeAttackRef;

    public void ActivateSlashingArt() => SlashEffect.SetBool("IsAttacking", true);

    public void DeactivateSlashingArt() => SlashEffect.SetBool("IsAttacking", false);
}
