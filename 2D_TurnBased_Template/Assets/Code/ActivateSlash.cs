using UnityEngine;

public class ActivateSlash : MonoBehaviour
{
    public Animator SlashEffect;
    public PlayerMeleeAttack PlayerMeleeAttackRef;

    public void ActivateSlashingArt() => SlashEffect.SetBool("IsSlashing", true);

    public void DeactivateSlashingArt() => SlashEffect.SetBool("IsSlashing", false);
}
