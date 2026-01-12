using UnityEngine;

public class ActivateSlash : MonoBehaviour
{
    public Animator SlashEffect;
    public PlayerMeleeAttack PlayerMeleeAttackRef;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SlashEffect.SetBool("IsSlashing", true);
            Debug.Log("hhhh");
        }
        else if(PlayerMeleeAttackRef.IsAttacking == false)
        {
            SlashEffect.SetBool("IsSlashing", false);
        }
    }
}
