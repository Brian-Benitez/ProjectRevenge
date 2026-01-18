using UnityEngine;

public class SpawnMovingDoor : MonoBehaviour
{
    public GameObject MovingDoorObj;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SpawnMoveDoor();
        }
    }
    public void SpawnMoveDoor () => MovingDoorObj.SetActive(true); 
}
