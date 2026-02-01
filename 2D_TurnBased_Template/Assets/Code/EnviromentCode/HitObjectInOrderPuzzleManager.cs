using System.Collections.Generic;
using UnityEngine;

public class HitObjectInOrderPuzzleManager : MonoBehaviour
{
    public List<ObjectHittableTrigger> HittableTriggers;
    public bool IsAllOn = false;
    int AllOnCount = 0;
    public DoorMoving DoorMovingRef;

    private void Update()
    {
        if(IsAllTriggersOn())
        {
            IsAllOn = true;
            DoorMovingRef.OpenDoor = true;
            RestartAllCountNumber();
        }
            
    }

    bool IsAllTriggersOn()
    {
        foreach(ObjectHittableTrigger trigger in HittableTriggers)
        {
            if(trigger.IsOn)
                AllOnCount++;
            else if(trigger.IsOn == false)
                AllOnCount--;
        }
        if(AllOnCount >= 3)
            return true;

        else return false;
    }
    void RestartAllCountNumber() => AllOnCount = 0;
}
