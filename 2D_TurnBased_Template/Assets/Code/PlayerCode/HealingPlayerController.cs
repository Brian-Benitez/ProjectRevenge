using UnityEngine;

public class HealingPlayerController : MonoBehaviour
{
    public static HealingPlayerController Instance;

    public PlayerInfo PlayerInfoRef;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
