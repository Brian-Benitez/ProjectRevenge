using UnityEngine;


public class Projectile : MonoBehaviour
{
    [Header("Projectiles info")]
    public float SpeedOfProjectile;
    public float LifeTimeOfProjectile;
    public float DistanceOfProjectile;
    public float MaxDistance;

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CharacterTypes == CharacterType.Player)
        {
            if (collision.CompareTag("Shield"))
            {
                Debug.Log("shield is hit");
                ShieldController.instance.ShieldHealth -= EnemyArcherGO.GetComponent<EnemyArcher>().EnemyDamage;
                DestroyProjectile();
            }
            else if (collision.CompareTag("EnemyShield"))
            {
                Debug.Log("hit enemy shield");
                collision.gameObject.GetComponent<EnemyShield>().ShieldTakeDamage(PlayerController.Instance.Player.gameObject.GetComponent<PlayerInfo>().RangeDamg);
            }
            else if (collision.CompareTag("Enemy"))
            {
                Debug.Log("hit enemy");
                collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(PlayerController.Instance.Player.gameObject.GetComponent<PlayerInfo>().RangeDamg);
                DestroyProjectile();
            }
        }
        if(CharacterTypes == CharacterType.Enemy)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("hit player");
                PlayerController.Instance.Player.GetComponent<BaseCharacter>().TakeDamage(EnemyArcherGO.GetComponent<EnemyArcher>().EnemyDamage);
                DestroyProjectile();
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

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
