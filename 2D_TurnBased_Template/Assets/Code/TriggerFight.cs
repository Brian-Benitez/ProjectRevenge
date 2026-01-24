using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerFight : MonoBehaviour
{
    [Header("Enemies In area")]
    public List<GameObject> Enemies;

    [Header("Fight ID")]
    public int FightID;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("spawn enemies now");
            ActivateAllEnemies();
            EnemysManager.Instance.DisableTrigger(FightID);
            EnemysManager.Instance.CurrentTriggerIndex = FightID;
            EnemysManager.Instance.CloseAllDoorsInLevel();
        }
    }
    /// <summary>
    /// Activates all eneimes if it dont work write it the long way
    /// </summary>
    void ActivateAllEnemies() => Enemies.ToList().ForEach(enemies => enemies.gameObject.SetActive(true));

}
