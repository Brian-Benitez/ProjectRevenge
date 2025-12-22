using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public GameObject EKeyButtonGO;

    bool WithinRange = false;   

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && WithinRange)
        {
            PlayerInventory.Instance.AddObjectToInventory(this.gameObject);
            Debug.Log("pick up object");
            gameObject.SetActive(false);//do something with this later
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EKeyButtonGO.SetActive(true);
            WithinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EKeyButtonGO.SetActive(false);
        WithinRange = false;
    }
}
