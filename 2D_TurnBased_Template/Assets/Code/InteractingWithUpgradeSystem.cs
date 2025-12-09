
using UnityEngine;

public class InteractingWithUpgradeSystem : MonoBehaviour
{
    public GameObject UpgradeUIGameObject;
    public GameObject EKeyPNG;

    public bool CanInteract = false;

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
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                UpgradeUIGameObject.SetActive(false);
            }
        }
        else
            UpgradeUIGameObject.SetActive(false);
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
