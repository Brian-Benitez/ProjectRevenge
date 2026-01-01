using UnityEngine;

public class ObjectHittableTrigger : MonoBehaviour
{
    public float Timer;
    public bool IsOn;

    float _maxTimer;

    private void Start()
    {
        _maxTimer = Timer;
    }
    private void Update()
    {
        if(IsOn)
        {
            Timer -= Time.deltaTime;
        }
        if(Timer <= 0)
        {
            IsOn = false;
            RestartTimer();
        }
    }


    public void TurnIsOnOn() => IsOn = true;
    public void TurnIsOnOff() => IsOn = false;
    void RestartTimer() => Timer = _maxTimer;
}
