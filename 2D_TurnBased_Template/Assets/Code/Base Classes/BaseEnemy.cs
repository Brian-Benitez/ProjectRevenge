using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float EnemyHealth;
    public float MaxEnemyHealth;
    public float EnemySpeed;
    public int EnemyDamage;

    [Header("Enemy Souls Value")]
    public int EnemySoulsValue;
    [Header("demo stuff delete later")]
    public bool IsHit = false;

    [Header("----------Stat Effects----------")]
    [Header("Stun Effect")]
    public bool IsStunned = false;//this controls the state to get off and on stuns effects
    public bool InstanteStun = false;//Normal grunt enemies
    public bool BuildUpStun  = false;//mini bosses/bosses
    [Header("Only use when build up stun is enabled.")]
    public int ThresholdHealthToStun;//Only use when build up stun is enabled.
    public float StunDuration;

    private void Start()
    {
        MaxEnemyHealth = EnemyHealth;
    }

    [SerializeField]
    public enum TypeOfEnemy
    {
        Swordsman, 
        Archer,
        Object
    }

    public enum LevelOfEnemy
    {
        Easy,
        Medium,
        Hard,
        Boss
    }

    public TypeOfEnemy EnemyType;
    public LevelOfEnemy EnemyDifficulty;

    public void TakeDamage(int  damage)
    {
        EnemyHealth -= damage;
        IsHit = true;   
        Debug.Log("enemy took: " + damage);
        DoesEnemyDie();
        CheckStatusEffects();
    }

    public void HealSelfFully() => EnemyHealth = MaxEnemyHealth;

    public void DoesEnemyDie()
    {
        if (EnemyHealth <= 0)
        {
            Debug.Log("im dead");
            SoulsBankController.instance.SoulsBank += EnemySoulsValue;
            SoulsBankController.instance.PayoutToPlayer();
            PlayerController.Instance.Player.GetComponent<BaseCharacter>().UpdatePlayersStats();//i dont like how im doing this give ref to SBC
            EnemysManager.Instance.RemoveEnemyFromList(this.gameObject);
            EnemysManager.Instance.EnableIsFullAggro();
            EnemysManager.Instance.IsAllEnemiesDead();
            Destroy(this.gameObject);
        }
        else
            Debug.Log("has health stil");
    }

    public void CheckStatusEffects()
    {
        if (InstanteStun)
            IsStunned = true;
        else if (BuildUpStun)
        {
            if(EnemyHealth <= ThresholdHealthToStun )
            {
                BuildUpStun = false;
                InstanteStun = true;
            }
        }
    }
}
