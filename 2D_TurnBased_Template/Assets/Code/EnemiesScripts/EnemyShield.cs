using Mono.Cecil.Cil;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public float EnemyShieldHealth;
    public GameObject Shield;
    public bool IsShieldBroken = false;

    public void TryTurningOnShield()
    {
        if(!IsShieldBroken)
        {
            Shield.SetActive(true);
            this.gameObject.tag = "EnemyShield";
            //this.gameObject.layer = 9;//enemy shield num
        }
    }

    public void TurnOffShield()
    {
        Shield.SetActive(false);
        this.gameObject.tag = "Enemy";
        this.gameObject.layer = 3;// enemy layer num
    }

    public void ShieldTakeDamage(float dam)
    {
        Debug.Log("shield is hit");
        EnemyShieldHealth -= dam;//this can make the shield health go to negative btw
        DoesShieldBreak();
    }
    public void DoesShieldBreak()
    {
        if (EnemyShieldHealth <= 0)
        {
            IsShieldBroken = true;
            Shield.SetActive(false);
            Debug.Log("shield is broken");
            return;
        }
        else
            IsShieldBroken = false;
    }
}
