using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink : Entity
{
    public Pink_IdleState idleState { get; private set; }

    public Pink_MoveState moveState { get; private set; }

    public Pink_PlayerDetectedState playerDetectedState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedStateData;

    public override void Start()
    {
        base.Start();

        moveState = new Pink_MoveState( this , stateMachine , "move" , moveStateData , this );

        idleState = new Pink_IdleState(this, stateMachine, "idle", idleStateData, this);

        playerDetectedState = new Pink_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);

        stateMachine.Initialize(moveState);
    }
}
