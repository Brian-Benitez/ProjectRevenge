using UnityEngine;

public class PlayerAmmoController : MonoBehaviour
{
    public static PlayerAmmoController Instance;

    public int AmmoAmount;
    public int MaxAmmoAmount;
    public bool HasAmmo = false;

    public PlayerInfo PlayerInfoRef;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public bool DoesPlayerHaveAmmo()
    {
        if (AmmoAmount > 0)
            return true;
        else return false;
    }

    public void AddAmmo(int amountofammo)
    {
        AmmoAmount += Mathf.Clamp(amountofammo, 0, MaxAmmoAmount);
    }

    public void RemoveAmmo()
    {
        AmmoAmount -= Mathf.Clamp(1, 0, MaxAmmoAmount);
        PlayerInfoRef.UpdatePlayersStats();
    }
}
