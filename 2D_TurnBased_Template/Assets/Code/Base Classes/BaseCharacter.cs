using DG.Tweening;
using TMPro;
using UnityEngine;

public class BaseCharacter : MonoBehaviour// need to move melee and rage values here. Want this to be main place to change values
{
    [Header("Health")]
    public float CharacterHealthAmount;
    public float CharacterMaxHealth;

    [Header("Range Dmg")]
    public float RangeDamg;
    [Header("Souls/XP")]
    public int Souls;
    [Header("Booleans")]
    public bool IsCharacterDead = false;
    [Header("Texts")]
    public TextMeshProUGUI PlayersHealth;
    public TextMeshProUGUI PlayersMaxHealth;
    public TextMeshProUGUI UpgradeUISoulsText;// will fix this later
    public TextMeshProUGUI PerksUISoulsText;//this too
    public TextMeshProUGUI InGameSoulsText;
    public TextMeshProUGUI UltAmountText;
    public TextMeshProUGUI MaxUltAmountText;
    public TextMeshProUGUI ArrowCountText;

    public HealthBarUI HealthBarUIRef;

    public void TakeDamage(float damage)
    {
        CharacterHealthAmount -= damage;
        SetHealth(-damage);
        Debug.Log("player took: " + damage);
        PlayersHealth.text = " " + CharacterHealthAmount;
        DoesCharacterDie();
    }

    public void SetHealth(float healthChange)
    {
        CharacterHealthAmount += healthChange;
        healthChange = Mathf.Clamp(CharacterHealthAmount, 0, CharacterMaxHealth);
        HealthBarUIRef.SetHealth(CharacterHealthAmount);
    }

    public void DoesCharacterDie()
    {
        if (CharacterHealthAmount <= 0)
        {
            IsCharacterDead = true;
            PlayerSpawnerController.Instance.SpawnPlayer();
            SetHealth(CharacterMaxHealth);
            UpdatePlayersStats();
            DoorController.instance.OpenAllDoorsInLevel();
            EnemysManager.Instance.EnableCurrentTriggerBox();
            EnemysManager.Instance.RepositionAllEnemiesInLevel();
            EnemysManager.Instance.HealsEnemiesInSection();
            EnemysManager.Instance.RestartAndTurnOffEnemies();
            Debug.Log("everything restarts");
        }
        else
        {
            Debug.Log("Still has health");
            IsCharacterDead = false;
        }

    }

    public void UpdatePlayersStats()
    {
        PlayersHealth.text = " " + CharacterHealthAmount;
        PlayersMaxHealth.text = " " + CharacterMaxHealth;
        UpgradeUISoulsText.text = " " + Souls;
        PerksUISoulsText.text = " " + Souls;
        InGameSoulsText.text = " " + Souls;
        UltAmountText.text = " " + PlayersUltController.Instance.UltPoints;
        MaxUltAmountText.text = " " + PlayersUltController.Instance.MaxUltPoints;
        ArrowCountText.text = " " + PlayerAmmoController.Instance.AmmoAmount;
    }
}
