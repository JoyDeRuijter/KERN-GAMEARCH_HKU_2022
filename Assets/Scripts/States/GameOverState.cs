using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseState
{
    public override void OnEnter()
    {
        Manager.Instance.gameOverMenu.SetActive(true);
        
    }

    public override void OnExit()
    {
        Manager.Instance.gameOverMenu.SetActive(false);
        for(int i = Manager.Instance.enemyManager.activePool.Count-1; i >= 0; i--)
        {
            EnemyController e = (EnemyController)Manager.Instance.enemyManager.activePool[i];
            e.Die();
        }
        Manager.Instance.amountOfCoins = Manager.Instance.startCoins;
    }

    public override void OnUpdate()
    {
       
    }
}
