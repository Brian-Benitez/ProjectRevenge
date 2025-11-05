using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int EnemyHealth;
    public int EnemySpeed;
    public int EnemyDamage;

    [Header("Enemy Souls Value")]
    public int EnemySoulsValue;

    public bool IsHit = false;


    [SerializeField]
    public enum TypeOfEnemy
    {
        Swordsman, 
        Archer
    }

    public TypeOfEnemy EnemyType;

    public void   TakeDamage(int  damage)
    {
        EnemyHealth -= damage;
        IsHit = true;   
        Debug.Log("enemy took: " + damage);
        DoesEnemyDie();
    }

    public void DoesEnemyDie()
    {
        if (EnemyHealth < 0)
        {
            //this.gameObject.gameObject.SetActive(false);
            Debug.Log("im dead");
            EnemysManager.Instance.AmountOfEnemies = -1;
            SoulsBankController.instance.SoulsBank += EnemySoulsValue;
            SoulsBankController.instance.PayoutToPlayer();
            PlayerController.Instance.Player.GetComponent<BaseCharacter>().UpdatePlayersStats();//i dont like how im doing this give ref to SBC
            Destroy(this.gameObject);
        }
        else
            Debug.Log("has health stil");
    }
}
