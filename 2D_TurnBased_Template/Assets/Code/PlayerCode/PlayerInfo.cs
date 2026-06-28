using UnityEngine;

public class PlayerInfo : BaseCharacter
{
    public GameObject PlayerObject;

    private void Start()
    {
        UpdatePlayersStats();
        HealthBarUIRef.SetUIMaxHealth(CharacterMaxHealth);
    }
}
