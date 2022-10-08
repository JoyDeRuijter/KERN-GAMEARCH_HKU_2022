using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{

    public List<EnemyController> activePool = new List<EnemyController>();
    private List<EnemyController> inactivePool = new List<EnemyController>();

    private List<Vector3Int> waypoints = new List<Vector3Int>() {
        new Vector3Int(2,0,0),
        new Vector3Int(9,0,6)
    };

    private int enemyAmount;

    public EnemyManager(int _amount)
    {
        enemyAmount = _amount;

        for(int i = 0; i < _amount; i++)
        {
            EnemyController e = new EnemyController(new Vector3(2,0,-1-i),waypoints,3,this);
            inactivePool.Add(e);
        }
    }
    
    public void OnStart()
    {
        foreach(EnemyController e in inactivePool)
        {
            e.OnStart();
        }
    }
    
    public void OnUpdate()
    {

        if(activePool.Count == 0)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Started");
                foreach(EnemyController e in inactivePool)
                {
                    activePool.Add(e);
                }
                inactivePool.Clear();
            }
        }

        for(int i = 0; i < activePool.Count; i++)
        {
            activePool[i].OnUpdate();
        }
    }

    public void ReturnToPool(EnemyController _e)
    {
        inactivePool.Add(_e);
        activePool.Remove(_e);
    }

}
