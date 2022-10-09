using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : BaseState
{
    private float timeLeft;

    public override void OnEnter()
    {
        Debug.Log("Building Phase Started");
        timeLeft = Manager.Instance.buildTime;
        Manager.Instance.buildingMenu.SetActive(true);
        Manager.Instance.buildingManager.shopUIManager.InitializeShopUI();
        Manager.Instance.coinCounter.SetActive(true);
        Manager.Instance.buildTimer.SetActive(true);
    }

    public override void OnExit()
    {
        Manager.Instance.buildingMenu.SetActive(false);
        Manager.Instance.buildTimer.SetActive(false);
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
