using UnityEngine;

public class PlayersUltController : MonoBehaviour
{
    public static PlayersUltController Instance;

    public bool IsUlted;
    public int UltPoints;
    public int MaxUltPoints;
    public float UltDuration;
    public float MaxUltDuration;
    public KeyCode UltActivationKey;

    public int BoostedMovementSpeed;
    public float LoweredDashCoolDown;

    public int MeleeUpgradeDam;
    public int RangeUpgradeDam;

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
                if (UltDuration <= 0)
                {
                    IsUlted = false;
                    SetPlayerToNormalStats();
                    RemoveAllUltPoints();
                    UltDuration += MaxUltDuration;
                }
                else
                {
                    UltDuration -= Time.deltaTime;
                    IsUlted = true;
                    ActivateUlt();
                }
            }
            
        }
    }

    public void ActivateUlt()
    {
        //Movement upgrade
        PlayerMovementRef.PlayerSpeed += BoostedMovementSpeed;
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
        PlayerMovementRef.PlayerSpeed -= BoostedMovementSpeed;
        PlayerMovementRef.DashCoolDown += LoweredDashCoolDown;

        //Melee upgrade
        PlayerMeleeAttackRef.PlayerLightAttkDamg -= MeleeUpgradeDam;
        PlayerMeleeAttackRef.PlayerHeavyAttkDamg -= MeleeUpgradeDam;

        //Range upgrade
        PlayerInfoRef.RangeDamg -= RangeUpgradeDam;
    }
    /// <summary>
    /// Made it like this so i can add objs that will max it or just give one. Only place to add it.
    /// </summary>
    /// <param name="amount"></param>
    public void AddUltPoint(int amount) => UltPoints += amount;
    /// <summary>
    /// Remove all ult points after using ult.
    /// </summary>
    public void RemoveAllUltPoints() => UltPoints = 0;
}
