using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [Header("Damg per sec in area")]
    public int DamPerTick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hello");
            PlayerController.Instance.Player.GetComponent<BaseCharacter>().TakeDamage(DamPerTick);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hello im here");
           //layerController.Instance.Player.GetComponent<BaseCharacter>().TakeDamage(DamPerTick);
        }
    }
}
