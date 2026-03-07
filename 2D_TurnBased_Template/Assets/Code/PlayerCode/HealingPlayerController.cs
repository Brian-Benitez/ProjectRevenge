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

    public void HealPlayer(float healamount)
    {
        if (PlayerInfoRef.CharacterHealthAmount == PlayerInfoRef.CharacterMaxHealth)
        {
            Debug.Log("health is full.");
        }
        else
        {
            PlayerInfoRef.CharacterHealthAmount += healamount;
        }

        if (PlayerInfoRef.CharacterHealthAmount > PlayerInfoRef.CharacterMaxHealth)
        {
            PlayerInfoRef.CharacterHealthAmount = PlayerInfoRef.CharacterMaxHealth;
        }
        PlayerInfoRef.UpdatePlayersStats();
    }
}
