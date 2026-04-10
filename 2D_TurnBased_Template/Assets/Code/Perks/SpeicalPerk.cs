using UnityEngine;

public class SpeicalPerk : MonoBehaviour
{
    [Header("Increase Radius of Special Settings")]
    public float AddedRadiusForSpeical;
    public bool IsUsingIncreaseRadiusPerk = false;

    public PlayerMeleeAttack PlayerMeleeAttackRef;

    public void ActivateIncreaseRadiusPerk() => IsUsingIncreaseRadiusPerk = true;

    public void ActivateSpeicalPerk()
    {
        if (IsUsingIncreaseRadiusPerk)
            IncreaseSpeicalRadius();
    }

    void IncreaseSpeicalRadius()
    {
        PlayerMeleeAttackRef.SpeicalRange += AddedRadiusForSpeical;
        Debug.Log("radius is increased");
    }

    public void RestartPlayerSpeicalSettings()
    {
        
    }
}
