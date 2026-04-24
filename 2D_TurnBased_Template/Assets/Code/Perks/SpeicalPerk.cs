using UnityEngine;

public class SpeicalPerk : MonoBehaviour
{
    [Header("Increase Radius of Special Settings")]
    public float AddedRadiusForSpeical;
    public bool IsUsingIncreaseRadiusPerk = false;
    public bool IsSpeicalPerkEquipped = false;

    public PlayerMeleeAttack PlayerMeleeAttackRef;

    public void ActivateIncreaseRadiusPerk() => IsUsingIncreaseRadiusPerk = true;

    public void ActivateSpeicalPerk()
    {
        if(!IsSpeicalPerkEquipped)
        {
            if (IsUsingIncreaseRadiusPerk)
                IncreaseSpeicalRadius();
        }
        else
        {
            Debug.Log("Cannot enable a perk, has perk already");
        }
    }

    void IncreaseSpeicalRadius()
    {
        IsSpeicalPerkEquipped = true;
        PlayerMeleeAttackRef.SpeicalRange += AddedRadiusForSpeical;
        Debug.Log("radius is increased");
    }

    public void RestartPlayerSpeicalSettings()
    {
        IsSpeicalPerkEquipped = false;
        if(IsUsingIncreaseRadiusPerk)
        {
            PlayerMeleeAttackRef.SpeicalRange -= AddedRadiusForSpeical;
            Debug.Log("radius is decrease");
        }
    }
}
