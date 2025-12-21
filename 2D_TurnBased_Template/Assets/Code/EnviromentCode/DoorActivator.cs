using Unity.VisualScripting;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public bool IsActivated = false;
    public bool CanInteractWithActivator = false;

    public GameObject EkeyObject;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanInteractWithActivator)
        {
            IsActivated = true;
            Debug.Log("open");
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EkeyObject.SetActive(true);
            CanInteractWithActivator = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EkeyObject.SetActive(false);
        CanInteractWithActivator = false;
    }
}
