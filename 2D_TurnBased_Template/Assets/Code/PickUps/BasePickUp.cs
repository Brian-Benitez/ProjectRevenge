using UnityEngine;
using UnityEngine.Events;

public class BasePickUp : MonoBehaviour
{
    public GameObject EKeyButtonGO;
    public enum TypeOfPickUp { Collectable, Potion};
    public TypeOfPickUp PickUpType;

    bool WithinRange = false;

    public UnityEvent OnPickUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && WithinRange)
        {
            if(PickUpType == TypeOfPickUp.Potion)
            {
                Debug.Log("pick up object");
                OnPickUp.Invoke();
                gameObject.SetActive(false);
            }
            else if(PickUpType == TypeOfPickUp.Collectable)
            {
                PlayerInventory.Instance.AddObjectToInventory(this.gameObject);
                Debug.Log("collected");
                gameObject.SetActive(false);
            }
           
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
