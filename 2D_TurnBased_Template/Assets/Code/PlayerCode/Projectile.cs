using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    [Header("Projectiles info")]
    public float SpeedOfProjectile;
    public float LifeTimeOfProjectile;
    public float DistanceOfProjectile;

    [Header("Enemy Ref")]
    public GameObject EnemyArcherGO;

    [Header("Layers")]
    public LayerMask Enemy;
    private void Start()
    {
        Invoke("DestroyProjectile", LifeTimeOfProjectile);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Shield"))
        {
            Debug.Log("shield is hit");
            ShieldController.instance.ShieldHealth -= EnemyArcherGO.GetComponent<EnemyArcher>().EnemyDamage;
            DestroyProjectile();
        }
        if(collision.CompareTag("Player"))
        {
            Debug.Log("hit player");
            PlayerController.Instance.Player.GetComponent<BaseCharacter>().TakeDamage(EnemyArcherGO.GetComponent<EnemyArcher>().EnemyDamage);
            DestroyProjectile();
        }
        else if(collision.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(PlayerController.Instance.Player.gameObject.GetComponent<PlayerInfo>().RangeDamg);
            DestroyProjectile();
        }
    }
    private void Update()
    {
            transform.Translate(Vector2.up * SpeedOfProjectile * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
