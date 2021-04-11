﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{

    protected D_PlayerDetectedState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;

    public PlayerDetectedState(Entity _entity, FiniteStateMachine _stateMachine, string _animBoolName , D_PlayerDetectedState _stateData) : base(_entity, _stateMachine, _animBoolName)
    {
        stateData = _stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0);

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();

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

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
    }
}
