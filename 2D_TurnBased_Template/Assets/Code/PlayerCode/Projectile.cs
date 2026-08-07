using UnityEngine;


public class Projectile : MonoBehaviour
{
    [Header("Projectiles info")]
    public Rigidbody2D RB;
    public float SpeedOfProjectile;
    public float LifeTimeOfProjectile;
    public float DistanceOfProjectile;
    public float MaxDistance;

    [Header("Enemy Ref")]
    public GameObject EnemyArcherGO;
    private Vector2 direction;
    
    public enum CharacterType
    {
        Player,
        Enemy
    }
    public enum TypeOfProjectile
    {
        Arrow,
        MagicMissle
    }

    [Header("Whos throwing them")]
    public CharacterType CharacterTypes;
    [Header("Type Of Projectile")]
    public TypeOfProjectile TypeOfProjectiles;

    private void Start()
    {
        Invoke("DestroyProjectile", LifeTimeOfProjectile);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        if (CharacterTypes == CharacterType.Player)
        {
            if (other.gameObject.CompareTag("Shield"))
            {
                Debug.Log("shield is hit");
                ShieldController.instance.ShieldHealth -= EnemyArcherGO.GetComponent<EnemyArcher>().EnemyDamage;
                DestroyProjectile();
            }
            else if (other.gameObject.CompareTag("EnemyShield"))
            {
                Debug.Log("hit enemy shield");
                other.gameObject.GetComponentInChildren<EnemyShield>().ShieldTakeDamage(PlayerController.Instance.Player.gameObject.GetComponent<PlayerInfo>().RangeDamg);
                DestroyProjectile();
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hit enemy");
                other.gameObject.GetComponent<BaseEnemy>().TakeDamage(PlayerController.Instance.Player.gameObject.GetComponent<PlayerInfo>().RangeDamg);
                DestroyProjectile();
            }
        }
        if (CharacterTypes == CharacterType.Enemy)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("hit player");
                PlayerController.Instance.Player.GetComponent<BaseCharacter>().TakeDamage(EnemyArcherGO.GetComponent<EnemyArcher>().EnemyDamage);
                DestroyProjectile();
            }
            if (other.gameObject.CompareTag("Shield"))
            {
                PlayerController.Instance.Player.GetComponent<ShieldController>().ShieldHealth -= EnemyArcherGO.GetComponent<EnemyArcher>().EnemyDamage;
                DestroyProjectile();
            }

            if (other.gameObject.CompareTag("Parry"))
            {
                Debug.Log("parry");
                var firstContact = other.contacts[0];
                Vector2 newVelocity = Vector2.Reflect(Vector2.up.normalized, firstContact.normal);
                ShootReflectedArrow(newVelocity.normalized);
            }
        }
    }

    private void Update()
    {
        if(TypeOfProjectiles == TypeOfProjectile.MagicMissle)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, SpeedOfProjectile * Time.deltaTime);
        }
        else if(TypeOfProjectiles == TypeOfProjectile.Arrow)
        {
            transform.Translate(Vector2.up * SpeedOfProjectile * Time.deltaTime);
        }
    }

    void ShootReflectedArrow(Vector2 direction)
    {
        this.direction = direction;
        RB.linearVelocity = this.direction * SpeedOfProjectile;
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
