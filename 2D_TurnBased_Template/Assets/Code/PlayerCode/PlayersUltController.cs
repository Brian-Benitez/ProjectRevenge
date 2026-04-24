using TMPro;
using UnityEngine;

public class PlayersUltController : MonoBehaviour
{
    public static PlayersUltController Instance;
    [Header("Ult Booleans")]
    public bool IsUsingPureRagePerk = false;
    public bool IsUsingRagePerk = false;

    [Header("Ult Settings")]
    public bool IsUlted;
    public bool IsUpgradeOn;
    public float UltPoints;
    public float MaxUltPoints;
    public float UltDuration;
    public KeyCode UltActivationKey;

    [Header("Pure Rage Perk Settings")]
    public int BoostedMovementSpeed;
    public float LoweredDashCoolDown;
    public int MeleeUpgradeDam;
    public int RangeUpgradeDam;

    public TextMeshProUGUI UltAmountText;
    public TextMeshProUGUI MaxUltAmountText;

    public PlayerMovement PlayerMovementRef;
    public PlayerMeleeAttack PlayerMeleeAttackRef;
    public PlayerInfo PlayerInfoRef;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        if(Input.GetKeyDown(UltActivationKey))
        {
            if(!IsUlted && UltPoints == MaxUltPoints)
            {
                IsUlted = true;
            }
        }

        if(IsUlted && UltDuration > 0)//add another check so it runs once
        {
            UltDuration -= Time.deltaTime;
        }
        else if(!IsUlted && UltDuration <= 0)
        {
            IsUlted = false;
            IsUpgradeOn = false;
            ResettingPlayerFromPerk();
            RemoveAllUltPoints();
            UltDuration += MaxUltPoints;
        }

        if(IsUlted && !IsUpgradeOn)
        {
            IsUpgradeOn = true;
            Debug.Log("Start ult");
            ActivateRagePerk();
        }
    }
    /// <summary>
    /// This is used when clicking on the button
    /// </summary>
    public void SetPureRageAsAPerk()
    {
        IsUsingPureRagePerk = true;
        IsUsingRagePerk = true;
    }
    public void CheckForDoubleEnablingPerks()//should move this to its own script.
    {
        if(!IsUsingRagePerk)
        {
            Debug.Log("can pick a perk");
        }
        else
        {
            Debug.Log("Is using a rage perk already");
        }
        
    }

    public void ActivateRagePerk()
    {
        if (IsUsingPureRagePerk)
            EnablePureRagePerk();
    }

    public void ResettingPlayerFromPerk()
    {
        if (IsUsingPureRagePerk)
            SetPlayerToNormalStats();
    }

    public void AddUltPoint(int amount)
    {
        UltPoints += amount;
        PlayerInfoRef.UpdatePlayersStats();
    }

    public void RemoveAllUltPoints() => UltPoints = 0;

    //--------------------------------------Pure Rage Perk Method----------------------------------------------------->
    public void EnablePureRagePerk()
    {
        IsUsingRagePerk = true;
        Debug.Log("is using pure rage perk!");
        //Movement upgrade
        PlayerMovementRef.FullSpeed += BoostedMovementSpeed;
        PlayerMovementRef.DashCoolDown -= LoweredDashCoolDown;

        //Melee upgrade
        PlayerMeleeAttackRef.PlayerLightAttkDamg += MeleeUpgradeDam;
        PlayerMeleeAttackRef.PlayerHeavyAttkDamg += MeleeUpgradeDam;

        //Range upgrade
        PlayerInfoRef.RangeDamg += RangeUpgradeDam;
    }
    public void SetPlayerToNormalStats()
    {
        //Movement upgrade
        PlayerMovementRef.FullSpeed -= BoostedMovementSpeed;
        PlayerMovementRef.DashCoolDown += LoweredDashCoolDown;

        //Melee upgrade
        PlayerMeleeAttackRef.PlayerLightAttkDamg -= MeleeUpgradeDam;
        PlayerMeleeAttackRef.PlayerHeavyAttkDamg -= MeleeUpgradeDam;

        //Range upgrade
        PlayerInfoRef.RangeDamg -= RangeUpgradeDam;
    }
    //add more  ult perks here.
   
    

    
}
