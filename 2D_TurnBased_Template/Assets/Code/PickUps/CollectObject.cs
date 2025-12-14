using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerInventory.Instance.AddObjectToInventory(this.gameObject);
            Debug.Log("pick up object");
            gameObject.SetActive(false);//do something with this later
        }
    }
}
