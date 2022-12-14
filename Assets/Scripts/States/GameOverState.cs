using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseState
{
    public override void OnEnter()
    {
        Manager.Instance.gameOverMenu.SetActive(true);
        Manager.Instance.coinCounter.SetActive(false);
    }

    public override void OnExit()
    {
        Manager.Instance.gameOverMenu.SetActive(false);
        Manager.Instance.health = Manager.Instance.startHealth;
        for(int i = Manager.Instance.enemyManager.activePool.Count-1; i >= 0; i--)
        {
            EnemyController e = (EnemyController)Manager.Instance.enemyManager.activePool[i];
            e.Health = Manager.Instance.enemyManager.startDecorator.Health;
            e.Die();
        }
        EventHandler.RaiseEvent(EventType.COINS_CHANGED, Manager.Instance.startCoins);
        Manager.Instance.buildingManager.DestroyAllPlacedObjects();
    }

    public override void OnUpdate()
    {
       
    }
}
