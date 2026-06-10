using System.Collections;
using UnityEngine;

public class StunState : State
{
    [Header("----------Stat Effects----------")]
    public bool IsStunned = false;
    [Header("Stun Effect")]
    public bool InstanteStun = false;
    public float StunDuration;

    private float MaxStunTime;
    public BaseEnemy BaseEnemyRef;
    public MovementState MovementStateRef;
    public KnockBackFeedBack KnockBackFeedBackRef;

    private void Start()
    {
        MaxStunTime = StunDuration;
    }
    /// <summary>
    /// Checks if enemy gets stunned + knocks enemies back as well.
    /// </summary>
    public void IsEnemyStunned()
    {
        if(InstanteStun)
        {
            IsStunned = true;
            StartCoroutine(StunLocked());
        }
        else
            IsStunned = false;
    }

    public IEnumerator StunLocked()
    {
        Debug.Log("is stunned");
        IsStunned = true;
        KnockBackFeedBackRef.PlayFeedBack(PlayerController.Instance.Player.gameObject);
        yield return new WaitForSeconds(MaxStunTime);
        IsStunned = false;
        Debug.Log("not stunned");
    }
    public override State RunCurrentState()
    {
        if (IsStunned == false)
            return MovementStateRef;
            
        return this;
    }
}
