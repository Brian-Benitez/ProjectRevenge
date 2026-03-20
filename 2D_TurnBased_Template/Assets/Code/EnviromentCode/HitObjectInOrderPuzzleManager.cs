using System.Collections.Generic;
using UnityEngine;

public class HitObjectInOrderPuzzleManager : MonoBehaviour
{
    public List<ObjectHittableTrigger> HittableTriggers;
    public bool IsAllOn = false;
    public int AllOnCount = 0;
    public DoorMoving DoorMovingRef;



    public void CheckIfCanDoorOpen()
    {
        if (IsAllTriggersOn())
        {
            IsAllOn = true;
            DoorMovingRef.OpenDoor = true;
            RestartAllCountNumber();
            Debug.Log("door is open");
        }
        else
            Debug.Log("cannot open door yet");
    }

    bool IsAllTriggersOn()
    {
        RestartAllCountNumber();
        foreach(ObjectHittableTrigger trigger in HittableTriggers)
        {
            if(trigger.IsOn)
                AllOnCount++;
        }
        if(AllOnCount >= 3)
            return true;

        else return false;
    }
    void RestartAllCountNumber() => AllOnCount = 0;
}
