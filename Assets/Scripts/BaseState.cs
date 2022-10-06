using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected FiniteStateMachine owner;

    public void Initialize(FiniteStateMachine _owner)
    {
        owner = _owner;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}
