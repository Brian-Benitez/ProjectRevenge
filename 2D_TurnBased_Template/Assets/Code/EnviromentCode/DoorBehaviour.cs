using UnityEngine;
using UnityEngine.Rendering;

public class DoorBehaviour : MonoBehaviour
{
    [Header("Timer info")]
    public bool NotOnTimer;
    public bool IsOnTimer;
    public float DoorTimer;
    private float _maxDoorTimer;

    [Header("Door info")]
    public float MovementAmount;
    public float HowFastDoorMoves;

    public DoorActivator DoorActivator;
    public DoorMoving DoorMovingRef;

    private void Start()
    {
        _maxDoorTimer = DoorTimer;
    }

    private void Update()
    {
        if(NotOnTimer && DoorActivator.IsActivated)
        {
            DoorMovingRef.OpenDoor = true;
            Debug.Log("open door");
        }
        else if(IsOnTimer && DoorActivator.IsActivated)
        {
            DoorTimer -= Time.deltaTime;

            if(DoorTimer <= 0)
            {
                DoorActivator.IsActivated = false;
                //CloseDoor();
            }
        }
    }
}
