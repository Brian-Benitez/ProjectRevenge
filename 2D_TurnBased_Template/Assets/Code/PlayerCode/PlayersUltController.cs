using TMPro;
using UnityEngine;

public class PlayersUltController : MonoBehaviour
{
    public static PlayersUltController Instance;
    [Header("Ult Booleans")]
    public bool IsUsingPureRagePerk = false;

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
            ResettingPlayerFromUlt();
            RemoveAllUltPoints();
            UltDuration += MaxUltPoints;
        }

        if(IsUlted && !IsUpgradeOn)
        {
            IsUpgradeOn = true;
            Debug.Log("Start ult");
            ActivateUlt();
        }
    }

    public void ActivateUlt()
    {
        if (IsUsingPureRagePerk)
            EnablePureRagePerk();
    }

    public void ResettingPlayerFromUlt()
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
