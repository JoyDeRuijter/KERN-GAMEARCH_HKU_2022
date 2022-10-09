using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("Attack Phase Started");
        Manager.Instance.enemyManager.StartAttack();
        //Debug.Log(Manager.Instance.enemyManager.activePool.Count);
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if(Manager.Instance.health == 0){
            owner.SwitchState(typeof(GameOverState));
        }

        if(Manager.Instance.enemyManager.activePool.Count == 0)
        {
            owner.SwitchState(typeof(BuildingState));
        }

        //?????
        //Manager.Instance.buildingManager.BuildingsAttack(Manager.Instance.enemyManager.) 
    }
}
