using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : BaseState
{
    public float buildTime = 30;
    float timeLeft;

    public override void OnEnter()
    {
        timeLeft = buildTime;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            owner.SwitchState(typeof(AttackState));
        }
    }


}
