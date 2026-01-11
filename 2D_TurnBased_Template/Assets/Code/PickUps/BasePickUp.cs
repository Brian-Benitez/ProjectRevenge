using UnityEngine;
using UnityEngine.Events;

public class BasePickUp : MonoBehaviour
{
    public GameObject EKeyButtonGO;

    bool WithinRange = false;

    public UnityEvent OnPickUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && WithinRange)
        {
            //PlayerInventory.Instance.AddObjectToInventory(this.gameObject);
            Debug.Log("pick up object");
            OnPickUp.Invoke();
            gameObject.SetActive(false);//do something with this later
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
