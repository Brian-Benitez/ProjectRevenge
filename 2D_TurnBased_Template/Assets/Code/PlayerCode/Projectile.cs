using UnityEngine;


public class Projectile : MonoBehaviour
{
    public Rigidbody2D Rb;
    [Header("Projectiles info")]
    public float SpeedOfMagicProjectile;
    public float ReturnSpeed;
    public float LifeTimeOfProjectile;
    public float DistanceOfProjectile;

    [Header("Enemy Ref")]
    public GameObject EnemyArcherGO;
    
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

            if (other.gameObject.CompareTag("Parry"))//does not work
            {
                Debug.Log("parry");
                Deflect(transform.up);
            }
        }
    }

    private void Update()
    {
        if(TypeOfProjectiles == TypeOfProjectile.MagicMissle)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, SpeedOfMagicProjectile * Time.deltaTime);
        }
    }


    public void Deflect(Vector2 direction)
    {
        /*
        if(direction.x > 0 && transform.right.x < 0 || direction.x <0 && transform.right.x > 0)
        {
            transform.right = -transform.right; 
        }
        */

        transform.up = -transform.up;
        Rb.linearVelocity = transform.up * ReturnSpeed;
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
