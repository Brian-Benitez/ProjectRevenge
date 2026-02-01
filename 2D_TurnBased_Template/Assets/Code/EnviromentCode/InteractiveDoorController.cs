using UnityEngine;
using UnityEngine.Rendering;

public class InteractiveDoorController : MonoBehaviour
{
    public DoorActivator DoorActivator;
    public DoorMoving DoorMovingRef;

    private void Update()
    {
        if(DoorActivator.IsActivated)
        {
            DoorMovingRef.OpenDoor = true;
            Debug.Log("open door");
        }
    }
}
