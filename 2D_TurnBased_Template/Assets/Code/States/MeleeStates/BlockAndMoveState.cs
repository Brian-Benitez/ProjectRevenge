using System.Collections;
using UnityEngine;

public class BlockAndMoveState : State
{
    public bool CanBlock = false;

    public int DieRollResult;
    public int PercentageToBlock;
    public float DurationOfBlock;
    float _maxDurationOfBlock;
    private EnemyShield _enemyShield;
    ChaseState ChaseStateRef;
    private float _distanceToMoveBack = 15f;
    private float _speedOfMovement = -3;

    private void Start()
    {
        _maxDurationOfBlock = DurationOfBlock;
        ChaseStateRef = GetComponent<ChaseState>();
        _enemyShield = GetComponent<EnemyShield>();
    }
    private void Update()
    {
        if(CanBlock)
        {
            _enemyShield.TryTurningOnShield();
            DurationOfBlock -= Time.deltaTime;
            if(DurationOfBlock > 0 )
            {
                if (Vector2.Distance(transform.position, PlayerController.Instance.Player.position) < _distanceToMoveBack)//idea being just move back
                {
                    transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.Player.position, _speedOfMovement * Time.deltaTime);
                }
            }
            else
            {
                _enemyShield.TurnOffShield();
                CanBlock = false;
                DurationOfBlock = _maxDurationOfBlock;
            }
            
        }
    }

    /// <summary>
    /// Randomly rolls to see if the enemy can block or not.
    /// </summary>
    public void RollingToBlock()
    {
        //check to see if enemies sheild is not broken here, if it isnt, then run this function full.
        DieRollResult = Random.Range(0, 100);

        if(DieRollResult <= PercentageToBlock)
            CanBlock = true;
        else
            CanBlock = false;
        Debug.Log("can block? " + CanBlock);
    }

    public override State RunCurrentState()
    {
        //if enemy cant block no more leave this state.
        if (!CanBlock)
            return ChaseStateRef;

        return this;
    }
}
