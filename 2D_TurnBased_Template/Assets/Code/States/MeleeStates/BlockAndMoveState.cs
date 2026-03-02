using UnityEngine;

public class BlockAndMoveState : State
{
    public bool CanBlock = false;

    public int DieRollResult;
    public int PercentageToBlock;
    public float DurationOfBlock;
    float _maxDurationOfBlock;
    private EnemyShield _enemyShield;
    MovementState ChaseStateRef;

    private void Start()
    {
        _maxDurationOfBlock = DurationOfBlock;
        ChaseStateRef = GetComponent<MovementState>();
        _enemyShield = GetComponent<EnemyShield>();
    }
    private void Update()
    {
        if(CanBlock)
        {
            DurationOfBlock -= Time.deltaTime;

            if(DurationOfBlock > 0 )
            {
                _enemyShield.TryTurningOnShield();
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
        if(CanBlock)
        {
            Debug.Log("cannot roll again is blocking already.");
            return;
        }
        else if(!_enemyShield.IsShieldBroken)
        {
            //check to see if enemies sheild is not broken here, if it isnt, then run this function full.
            DieRollResult = Random.Range(0, 100);

            if (DieRollResult <= PercentageToBlock)
                CanBlock = true;
            else
                CanBlock = false;
            Debug.Log("can block? " + CanBlock);

        }
            
    }

    public override State RunCurrentState()
    {
        //if enemy cant block no more leave this state.
        if (!CanBlock || _enemyShield.IsShieldBroken)
        {
            _enemyShield.TurnOffShield();
            return ChaseStateRef;
        }
           

        return this;
    }
}
