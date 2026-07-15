using System.Collections.Generic;
using UnityEngine;

public class UpgradeEnemiesController : MonoBehaviour
{
    public float ShieldUpgradeIncrement;
    public float Increments;

    public void AddToShieldIncrement() => ShieldUpgradeIncrement += Increments;

    public void UpgradeEnemyShields(List<GameObject> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<EnemyShield>().EnemyShieldHealth = 0;
            enemies[i].GetComponent<EnemyShield>().EnemyShieldHealth += ShieldUpgradeIncrement;
            enemies[i].GetComponent<EnemyShield>().TryTurningOnShield();
        }
    }

    public void RestartEnemyShields(List<GameObject> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<EnemyShield>().EnemyShieldHealth = 0;
            enemies[i].GetComponent<EnemyShield>().TurnOffShield();
        }
    }
}
