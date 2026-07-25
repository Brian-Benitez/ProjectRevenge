using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public float EnemyShieldHealth;
    public GameObject EnemyParentObject;
    public GameObject Shield;
    public bool IsShieldBroken = false;

    public void TryTurningOnShield()
    {
        if(!IsShieldBroken)
        {
            Shield.SetActive(true);
            EnemyParentObject.gameObject.tag = "EnemyShield";
        }
    }

    public void TurnOffShield()
    {
        Shield.SetActive(false);
        EnemyParentObject.tag = "Enemy";
        EnemyParentObject.layer = 3;// enemy layer num
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
            EnemyParentObject.gameObject.tag = "Enemy";
            return;
        }
        else
            IsShieldBroken = false;
    }
}
