using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int EnemyHealth;
    public int EnemySpeed;
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
    public float StunDuration;
    public int AmountOfHitsForStun, MaxHitForStun;


    [SerializeField]
    public enum TypeOfEnemy
    {
        Swordsman, 
        Archer
    }

    public TypeOfEnemy EnemyType;

    public void TakeDamage(int  damage)
    {
        EnemyHealth -= damage;
        IsHit = true;   
        Debug.Log("enemy took: " + damage);
        DoesEnemyDie();
        CheckStatusEffects();
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

    public void CheckStatusEffects()
    {
        if (InstanteStun)
            IsStunned = true;
        else if (BuildUpStun)
            AmountOfHitsForStun++;

        if (AmountOfHitsForStun >= MaxHitForStun)
            IsStunned = true;
    }
}
