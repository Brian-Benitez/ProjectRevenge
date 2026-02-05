using DG.Tweening;
using TMPro;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [Header("Name")]
    public string NameOfCharacter;
    [Header("Health")]
    public int CharacterHealthAmount;
    public int CharacterMaxHealth;
    public int CharacterMaxHealthLevel;
    [Header("Rage Ult Points")]
    public int RageUltAmount;
    public int RageMaxUltAmount;
    [Header("Range Dmg")]
    public int RangeDamg;
    [Header("Souls/XP")]
    public int Souls;
    [Header("Booleans")]
    public bool IsCharacterDead = false;
    [Header("Texts")]
    public TextMeshProUGUI PlayersHealth;
    public TextMeshProUGUI PlayersMaxHealth;
    public TextMeshProUGUI StatueSoulsText;
    public TextMeshProUGUI InGameSoulsText;

    public void TakeDamage(int damage)
    {
        CharacterHealthAmount -= damage;
        Debug.Log(NameOfCharacter + " took: " + damage);
        PlayersHealth.text = " " + CharacterHealthAmount;
        DoesCharacterDie();
    }

    public void HealAllHealth() => CharacterHealthAmount = CharacterMaxHealth;//dont wanna add other var maybe do health level list take val there

    public void DoesCharacterDie()
    {
        if (CharacterHealthAmount <= 0)
        {
            IsCharacterDead = true;
            PlayerSpawnerController.Instance.SpawnPlayer();
            HealAllHealth();
            UpdatePlayersStats();
            EnemysManager.Instance.RestartEneimes();
            DoorController.instance.OpenAllDoorsInLevel();
        }
        else
        {
            Debug.Log(NameOfCharacter + " Still has health");
            IsCharacterDead = false;
        }

    }

    public void UpdatePlayersStats()
    {
        PlayersHealth.text = " " + CharacterHealthAmount;
        PlayersMaxHealth.text = " " + CharacterMaxHealthLevel;
        StatueSoulsText.text = " " + Souls;
        InGameSoulsText.text = " " + Souls;
    }
}
