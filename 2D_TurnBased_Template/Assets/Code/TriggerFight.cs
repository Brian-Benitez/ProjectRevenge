using System.Collections.Generic;
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

        }
    }
}
