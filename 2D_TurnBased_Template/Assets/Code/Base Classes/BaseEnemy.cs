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

    public bool IsDead = false;

    public HitPauseController HitPauseControllerRef;
    public StunState StunStateRef;

    private void Start()
    {
        MaxEnemyHealth = EnemyHealth;
    }

    [SerializeField]
    public enum TypeOfEnemy
    {
        Swordsman, 
        Archer,
        Boss,
        Object
    }

    public enum LevelOfEnemy
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        Boss
    }

    public TypeOfEnemy EnemyType;
    public LevelOfEnemy EnemyDifficulty;

    public void TakeDamage(float damage)
    {
        EnemyHealth -= damage;
        IsHit = true;   
        Debug.Log("enemy took: " + damage);
        StunStateRef.IsEnemyStunned();
        DoesEnemyDie();
    }

    public void HealSelfFully() => EnemyHealth = MaxEnemyHealth;

    public void DoesEnemyDie()
    {
        if (EnemyHealth <= 0)
        {
            Debug.Log("im dead");
            if (EnemyType == TypeOfEnemy.Object)
                Debug.Log("object destroyed");

            else
            {
                SoulsBankController.instance.SoulsBank += EnemySoulsValue;
                EnemiesSpawner.Instance.EnemiesAlive--;
                EnemiesSpawner.Instance.CheckOnTotalEnemies();
                SoulsBankController.instance.PayoutToPlayer();
                PlayerAmmoController.Instance.AddAmmo(1);
                PlayerController.Instance.Player.GetComponent<BaseCharacter>().UpdatePlayersStats();//i dont like how im doing this give ref to SBC
                EnemyTurnController.Instance.RemoveAsDirectThreat();
                EnemyTurnController.Instance.RemoveEnemyFromList(this.gameObject);
                DropAnItem();
                IsDead = true;
            }  
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            if (EnemyType != TypeOfEnemy.Boss)//temp
            {
                HitPauseControllerRef.PlayHitPauseCoroutine();
            }
            Debug.Log("has health stil");
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
