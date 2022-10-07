using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager: MonoBehaviour
{
    private FiniteStateMachine fsm;

    // Start is called before the first frame update
    void OnStart()
    {
        fsm = new FiniteStateMachine(typeof(StartState), GetComponents<BaseState>());
    }

    // Update is called once per frame
    void OnUpdate()
    {
        fsm.OnUpdate();
    }
}
