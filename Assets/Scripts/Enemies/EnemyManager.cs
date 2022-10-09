using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{

    public List<IEnemy> activePool = new List<IEnemy>();
    private List<IEnemy> inactivePool = new List<IEnemy>();

    private List<Vector3Int> waypoints = new List<Vector3Int>() {
        new Vector3Int(2,0,0),
        new Vector3Int(9,0,10),
        new Vector3Int(1,0,7),
        new Vector3Int(4,0,14),
        new Vector3Int(9,0,19),
        new Vector3Int(3,0,23)
    };

    private int enemyAmount;

    private EnemyDecorator startDecorator = new EnemyDecorator(20,5);
    public EnemyDecorator modifier = new EnemyDecorator(5,1);

    public EnemyManager(int _amount)
    {
        enemyAmount = _amount;

        for(int i = 0; i < _amount; i++)
        {
            IEnemy e = new EnemyController(new Vector3(2,0,-1-i),waypoints,4,this);
            e = startDecorator.Decorate(e);
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
            EnemyController e = (EnemyController)activePool[i];
            e.OnUpdate();
        }
    }

    public void StartAttack()
    {
        Debug.Log("Started");
        foreach(EnemyController e in inactivePool)
        {
            activePool.Add(e);
        }
        inactivePool.Clear();
    }

    public void ReturnToPool(EnemyController _e)
    {
        inactivePool.Add(_e);
        activePool.Remove(_e);
    }

    public void AddModifier(IEnemy _e)
    {
        // int index = inactivePool.IndexOf(_e);
        // inactivePool[index] = modifier.Decorate(inactivePool[index]);
        Debug.Log("Added modifier");
        _e = modifier.Decorate(_e);
    }

}
