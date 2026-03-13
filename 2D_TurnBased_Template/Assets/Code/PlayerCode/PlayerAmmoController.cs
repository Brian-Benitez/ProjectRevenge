using UnityEngine;

public class PlayerAmmoController : MonoBehaviour
{
    public static PlayerAmmoController Instance;

    public int AmmoAmount;
    public bool HasAmmo = false;

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

    public void AddAmmo()
    {
        AmmoAmount++;
    }

    public void RemoveAmmo()
    {
        AmmoAmount--;
    }
}
