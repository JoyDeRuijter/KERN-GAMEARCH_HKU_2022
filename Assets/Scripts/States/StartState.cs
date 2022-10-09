using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : BaseState
{
    public override void OnEnter()
    {
        //Debug.Log("Main Menu");
        Manager.Instance.startMenu.SetActive(true);
        Manager.Instance.coinCounter.SetActive(false);
    }
    public override void OnExit()
    {
        Manager.Instance.startMenu.SetActive(false);
    }
    public override void OnUpdate()
    {
    }
}
