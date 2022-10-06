using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    private Dictionary<System.Type, BaseState> stateDictionary = new Dictionary<System.Type, BaseState>();
    public BaseState currentState;

    public FiniteStateMachine(System.Type startState, params BaseState[] states)
    {
        foreach (BaseState state in states)
        {
            state.Initialize(this);
            stateDictionary.Add(state.GetType(), state);
        }
        SwitchState(startState);
    }
    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }

    public void SwitchState(System.Type newStateType)
    {
        currentState?.OnExit();
        currentState = stateDictionary[newStateType];
        currentState?.OnEnter();
    }
}
