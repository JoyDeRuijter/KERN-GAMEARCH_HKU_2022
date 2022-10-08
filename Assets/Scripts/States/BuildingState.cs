using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : BaseState
{
    float timeLeft;

    public override void OnEnter()
    {
        Debug.Log("Building Phase Started");
        timeLeft = Manager.Instance.buildTime;
        Manager.Instance.buildingMenu.SetActive(true);
        Manager.Instance.buildingManager.InitializeShopUI();
    }

    public override void OnExit()
    {
        Manager.Instance.buildingMenu.SetActive(false);
    }

    public override void OnUpdate()
    {
        //Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            owner.SwitchState(typeof(AttackState));
        }
    }


}
