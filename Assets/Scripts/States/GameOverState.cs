using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("Game Over");
        Manager.Instance.gameOverMenu.SetActive(true);
    }

    public override void OnExit()
    {
        Manager.Instance.gameOverMenu.SetActive(false);
    }

    public override void OnUpdate()
    {
       
    }
}
