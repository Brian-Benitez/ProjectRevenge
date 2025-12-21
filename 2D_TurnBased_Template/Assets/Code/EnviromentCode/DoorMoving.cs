using UnityEngine;

public class DoorMoving : MonoBehaviour
{
    public bool OpenDoor;
    public bool CloseDoor;

    public GameObject ClosePoint;
    public GameObject OpenPoint;

    public float MovementSpeed;

    private void Update()
    {
        if(OpenDoor)
        {
            MoveDoorToOpen();
            if(Vector2.Distance(transform.position, OpenPoint.transform.position) <= 0)
            {
                OpenDoor = false;
                CloseDoor = false;
            }
        }
        else if(CloseDoor)
        {
            MoveDoorToClose();
            if (Vector2.Distance(transform.position, ClosePoint.transform.position) <= 0)
            {
                OpenDoor = false;
                CloseDoor = false;
            }
        }
    }

    void MoveDoorToOpen()
    {
        transform.position = Vector2.MoveTowards(transform.position, OpenPoint.transform.position, MovementSpeed * Time.deltaTime);
    }

    void MoveDoorToClose()
    {
        transform.position = Vector2.MoveTowards(transform.position, ClosePoint.transform.position, MovementSpeed * Time.deltaTime);
    }
}
