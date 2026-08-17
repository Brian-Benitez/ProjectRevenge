using UnityEngine;

public class ActivateSlash : MonoBehaviour
{
    public Animator SlashEffect;
    public PlayerMeleeAttack PlayerMeleeAttackRef;
    public SpriteRenderer SpriteRendererRef;

    public void ActivateSlashingArt()
    {
        SpriteRendererRef.gameObject.SetActive(true);   
        SlashEffect.SetBool("IsAttacking", true);
    }

    public void DeactivateSlashingArt()
    {
        SlashEffect.SetBool("IsAttacking", false);
        SpriteRendererRef.gameObject.SetActive(false);
    }
}
