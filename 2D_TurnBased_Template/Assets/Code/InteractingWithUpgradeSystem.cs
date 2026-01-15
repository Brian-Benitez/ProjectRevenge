
using UnityEngine;

public class InteractingWithUpgradeSystem : MonoBehaviour
{
    public GameObject UpgradeUIGameObject;
    public GameObject EKeyPNG;

    public bool CanInteract = false;
    public bool IsInteracting = false;
    public PlayerMovement PlayerMovementRef;

    private void Start()
    {
        UpgradeUIGameObject.SetActive(false);
    }

    private void Update()
    {
        if (CanInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UpgradeUIGameObject.SetActive(true);
                IsInteracting = true;
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                UpgradeUIGameObject.SetActive(false);
                IsInteracting = false;
                
            }
        }
        //makes player not move when in menu
        if(IsInteracting)
            PlayerMovementRef.TurnOnStopPlayerMovement();
        else if(!IsInteracting)
            PlayerMovementRef.TurnOffStopPlayerMovement();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        CanInteract = true;
        EKeyPNG.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        CanInteract = false;
        EKeyPNG.SetActive(false);
    }
}
