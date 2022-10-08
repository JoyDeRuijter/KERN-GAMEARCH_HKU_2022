using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{

    public override void OnEnter()
    {
        Debug.Log("Attack Phase Started");
        Manager.Instance.enemies.StartAttack();
        Debug.Log(Manager.Instance.enemies.activePool.Count);
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        //if health = 0 game over
        if(Manager.Instance.health == 0){
            owner.SwitchState(typeof(GameOverState));
        }

        //als alle enemies dood zijn switch state [buildingstate]
        if(Manager.Instance.enemies.activePool.Count == 0)
        {
            owner.SwitchState(typeof(BuildingState));
        }
    }

}
