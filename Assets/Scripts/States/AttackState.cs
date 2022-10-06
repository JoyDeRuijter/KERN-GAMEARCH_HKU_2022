using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        //als alle enemies dood zijn switch state [buildingstate]
        //als health = 0 switch state [gameoverstate]
    }

}
