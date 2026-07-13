using UnityEngine;

public class XPController : MonoBehaviour
{
    public static XPController Instance;
    public BaseCharacter PlayerStats;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddXPToPlayer(int xpamount)
    {
        PlayerStats.XP += xpamount;
    }
}
