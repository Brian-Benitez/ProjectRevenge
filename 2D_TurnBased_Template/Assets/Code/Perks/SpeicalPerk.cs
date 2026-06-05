using UnityEngine;

public class SpeicalPerk : MonoBehaviour
{
    [Header("Increase Radius of Special Settings")]
    public float AddedRadiusForSpeical;
    public bool IsUsingIncreaseRadiusPerk = false;
    public bool IsUsingRageQuakePerk = false;
    public bool IsSpeicalPerkEquipped = false;
    public bool IsNotUsingAnyPerks = false;

    public PlayerMeleeAttack PlayerMeleeAttackRef;

    public void ActivateIncreaseRadiusPerk() => IsUsingIncreaseRadiusPerk = true;
    public void ActivateRageQuakePerk() => IsUsingRageQuakePerk = true;
    public void TurnOffSpeicalPerks() => IsNotUsingAnyPerks = true;

    public void ActivateSpeicalPerk()
    {
        if(!IsSpeicalPerkEquipped)
        {
           // if (IsUsingIncreaseRadiusPerk)
               // IncreaseSpeicalRadius();
            //if (IsUsingRageQuakePerk)
               // RageQuakeUpgrade();
        }
        else
        {
            Debug.Log("Cannot enable a perk, has perk already");
        }
    }
    /*
    void IncreaseSpeicalRadius()
    {
        PlayerMeleeAttackRef.SpeicalRange += Mathf.Clamp(AddedRadiusForSpeical, 0, 3.9f);
        PlayerMeleeAttackRef._maxwaitTimeForSpeical += .16f;//increase wait time 
        Debug.Log("radius is increased");
    }
    */
    /*
    void RageQuakeUpgrade()
    {
        IsSpeicalPerkEquipped = true;
        PlayerMeleeAttackRef.PlayerSpecialDamg += 1;
        PlayerMeleeAttackRef.SpeicalRange -= 0.6f;
        Debug.Log("increased speical damg");
    }
    */

    public void RestartPlayerSpeicalSettings()
    {
        IsSpeicalPerkEquipped = false;
        if(IsUsingIncreaseRadiusPerk)
        {
            PlayerMeleeAttackRef.SpeicalRange -= Mathf.Clamp(AddedRadiusForSpeical, 0, 3.9f);
            PlayerMeleeAttackRef._maxwaitTimeForSpeical -= .16f;
            Debug.Log("radius is decrease");
        }
        if(IsUsingRageQuakePerk)
        {
            PlayerMeleeAttackRef.SpeicalRange += 0.6f;
            PlayerMeleeAttackRef.PlayerSpecialDamg -= 1;
            Debug.Log("removed rage quake perk");
        }
        if(IsNotUsingAnyPerks)
        {
            PlayerMeleeAttackRef.SpeicalRange = 3f;
        }    
    }

    public void TurnOffAllBoolsInSpeicalPerk()
    {
        IsUsingRageQuakePerk = false;
        IsUsingIncreaseRadiusPerk = false;
    }
}
