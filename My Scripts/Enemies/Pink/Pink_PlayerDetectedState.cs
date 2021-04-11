using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink_PlayerDetectedState : PlayerDetectedState
{

    private Pink pink;

    public Pink_PlayerDetectedState(Entity _entity, FiniteStateMachine _stateMachine, string _animBoolName, D_PlayerDetectedState _stateData,Pink _pink) : base(_entity, _stateMachine, _animBoolName, _stateData)
    {
        pink = _pink;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isPlayerInMaxAgroRange)
        {
            pink.idleState.SetFlip(false);
            stateMachine.ChangeState(pink.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
