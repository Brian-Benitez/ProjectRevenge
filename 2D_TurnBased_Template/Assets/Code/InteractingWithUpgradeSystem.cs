using Unity.VisualScripting;
using UnityEngine;

public class InteractingWithUpgradeSystem : MonoBehaviour
{
    public GameObject UpgradeUIGameObject;

    private void Start()
    {
        UpgradeUIGameObject.SetActive(false);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            UpgradeUIGameObject.SetActive(true);
        }
    }
}
