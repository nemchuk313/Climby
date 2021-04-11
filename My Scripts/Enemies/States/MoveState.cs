using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    public MoveState(Entity _entity, FiniteStateMachine _stateMachine, string _animBoolName , D_MoveState _stateData) : base(_entity, _stateMachine, _animBoolName)
    {
        stateData = _stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(stateData.moveSpeed);

        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CkeckLedge();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CkeckLedge();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}
