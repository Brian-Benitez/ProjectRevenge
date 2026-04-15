using System.Collections;
using UnityEngine;

public class PlayerStunnedState : MonoBehaviour//WORK IN PROGRESS
{
    public float StunDuration;
    public bool IsPlayerStuuned = false;

    public void ActivatePlayerStunned() => StartCoroutine(PlayerStunned());
    private IEnumerator PlayerStunned()
    {
        IsPlayerStuuned = true;
        Debug.Log("player is stunned");
        yield return new WaitForSecondsRealtime(StunDuration);
        Debug.Log("player is no longer stunned");
        IsPlayerStuuned = false;
    }
}
