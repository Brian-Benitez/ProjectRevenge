using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public int EnemyShieldHealth;
    public GameObject Shield;
    public bool IsShieldBroken = false;

    public void TryTurningOnShield()
    {
        if(!IsShieldBroken)
        {
            Shield.SetActive(true);
            this.gameObject.tag = "EnemyShield";
        }
    }

    public void TurnOffShield()
    {
        Shield.SetActive(false);
        this.gameObject.tag = "Enemy";
    }

    public void ShieldTakeDamage(int dam)
    {
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
