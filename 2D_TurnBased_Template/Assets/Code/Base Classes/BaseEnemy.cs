using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float EnemyHealth;
    public float MaxEnemyHealth;
    public float EnemySpeed;
    public float EnemyDamage;
    [Header("Item that can be dropped")]
    public GameObject HealthPotion;
    public GameObject RagePotion;
    public int ChanceToDropItem;

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

    public EnemyAggroDistance EnemyAggroDistanceRef;
    public DetermineEnemyPriority DetermineEnemyPriorityRef;
    KnockBackFeedBack _knockBackFeedBack;

    private void Start()
    {
        MaxEnemyHealth = EnemyHealth;
        _knockBackFeedBack = GetComponent<KnockBackFeedBack>();
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

    private void Update()
    {
        if (IsHit && IsStunned)
        {
            _knockBackFeedBack.PlayFeedBack(PlayerController.Instance.Player.gameObject);
            IsHit = false;
            Debug.Log("KNOCKED BACK");
        }
    }

    public void TakeDamage(float damage)
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
            EnemysManager.Instance.RemoveEnemyFromList(this.gameObject);
            //EnemysManager.Instance.EnableIsFullAggroToAnotherEnemy();
            EnemysManager.Instance.IsAllEnemiesDead();
            PlayerAmmoController.Instance.AddAmmo();
            PlayerController.Instance.Player.GetComponent<BaseCharacter>().UpdatePlayersStats();//i dont like how im doing this give ref to SBC
            EnemyTurnController.Instance.RemoveAsDirectThreat();
            EnemyTurnController.Instance.RemoveEnemyFromList(this.gameObject);
            DropAnItem();
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
    /// <summary>
    /// rolls to see if the enemy drops an item or not.
    /// </summary>
    private void DropAnItem()
    {
        int chance = Random.Range(0, 100);

        if(chance <= ChanceToDropItem)
        {
            int random = Random.Range(0, 10);
            if (random <= 5)
            {
                Instantiate(HealthPotion, transform.position, Quaternion.identity);
                Debug.Log("dropped health");
            }
            else
            {
                Instantiate(RagePotion, transform.position, Quaternion.identity);
                Debug.Log("dropped rage");
            }
        }
        else
        {
            Debug.Log("did not drop anything");
        }
       
    }
}
