using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    
    public Vector3 position;

    private EnemyManager enemyManager;

    private float moveSpeed;

    private GameObject body;
    
    private Vector3 startPosition;
    private Vector3Int nextPosition;

    private List<Vector3Int> waypoints = new List<Vector3Int>();
    private int waypointIndex = 0;

    public EnemyController(Vector3 _startPos, List<Vector3Int> _waypoints, float _moveSpeed, EnemyManager _manager)
    {
        enemyManager = _manager;

        position = _startPos;
        
        nextPosition = Vector3Int.RoundToInt(_startPos);
        startPosition = _startPos;
        waypoints = _waypoints;

        moveSpeed = _moveSpeed;
    }

    public void OnStart()
    {
        body = GameObject.Instantiate(Manager.Instance.enemyPrefab,position,Quaternion.identity);
    }

    public void OnUpdate()
    {
        body.transform.position = position;
        MoveTowardsTarget(waypoints[waypointIndex]);

        if(Vector3.Distance(position,waypoints[waypointIndex]) <= 0.05f)
        {
            if(waypointIndex >= waypoints.Count-1){
                //Die();
                nextPosition = waypoints[waypointIndex];
                position = waypoints[waypointIndex];
                AttackBase();
            }
            else
            {
                waypointIndex++;
            }        
        }
    }

    public void TakeDamage(float _dmg) {}

    private void Die()
    {
        waypointIndex = 0;
        position = startPosition;
        body.transform.position = position;
        nextPosition = Vector3Int.FloorToInt(startPosition);
        enemyManager.ReturnToPool(this);
    }

    float timeLeft = 1f;
    private void AttackBase()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            //Manager.Instance.health -= 0.5f;
            Debug.Log("Do Damage to Base");
            timeLeft = 1f;
        }
    }

    public void MoveTowardsTarget(Vector3Int _target)
    {

        position = Vector3.MoveTowards(position,nextPosition,moveSpeed*Time.deltaTime);

        if(Vector3.Distance(position,nextPosition) <= 0.05f) {

            if(Mathf.Abs(_target.x-position.x) >= Mathf.Abs(_target.z-position.z)) {

                if(_target.x > position.x) {
                    if(CanMove("Right")) {
                        Move("Right");
                    }
                    else {
                        if(_target.z < position.z) {
                            if(CanMove("Down")) {
                                Move("Down");
                            }
                        }
                        else if(_target.z > position.z) {
                            if(CanMove("Up")) {
                                Move("Up");
                            }
                        }
                    }
                }
                else if(_target.x < position.x) {
                    if(CanMove("Left")) {
                        Move("Left");
                    }
                    else {
                        if(_target.z < position.z) {
                            if(CanMove("Down")) {
                                Move("Down");
                            }
                        }
                        else if(_target.z > position.z) {
                            if(CanMove("Up")) {
                                Move("Up");
                            }
                        }
                    }
                }
            }

            if(Mathf.Abs(_target.x-position.x) < Mathf.Abs(_target.z-position.z)) {

                if(_target.z < position.z) {
                    if(CanMove("Down")) {
                        Move("Down");
                    }
                    else {
                        if(_target.x > position.x) {
                            if(CanMove("Right")) {
                                Move("Right");
                            }
                        }
                        else if(_target.x < position.x) {
                            if(CanMove("Left")) {
                                Move("Left");
                            }
                        }
                    }
                }
                else if(_target.z > position.z) {
                    if(CanMove("Up")) {
                        Move("Up");
                    }
                    else {
                        if(_target.x > position.x) {
                            if(CanMove("Right")) {
                                Move("Right");
                            }
                        }
                        else if(_target.x < position.x) {
                            if(CanMove("Left")) {
                                Move("Left");
                            }
                        }
                    }
                }
            }

        }

    }

    private void Move(string _dir)
    {

        int x = nextPosition.x;
        int z = nextPosition.z;

        switch(_dir)
        {
            case "Right":
                x = nextPosition.x+1;
                z = nextPosition.z;
                break;
            
            case "Left":
                x = nextPosition.x-1;
                z = nextPosition.z;
                break;
            
            case "Up":
                x = nextPosition.x;
                z = nextPosition.z+1;
                break;
            
            case "Down":
                x = nextPosition.x;
                z = nextPosition.z-1;
                break;

        }

        nextPosition = new Vector3Int(x,0,z);

    }

    private bool CanMove(string _dir)
    {

        bool canMove = true;

        int x = nextPosition.x;
        int z = nextPosition.z;

        switch(_dir)
        {
            case "Right":
                x = nextPosition.x+1;
                z = nextPosition.z;
                break;
            
            case "Left":
                x = nextPosition.x-1;
                z = nextPosition.z;
                break;
            
            case "Up":
                x = nextPosition.x;
                z = nextPosition.z+1;
                break;
            
            case "Down":
                x = nextPosition.x;
                z = nextPosition.z-1;
                break;

        }

        Vector3Int pos = new Vector3Int(x,0,z);

        if(Manager.Instance.level.ContainsKey(pos))
        {

            if(Manager.Instance.level[pos].type == TileType.WALL)
            {
                canMove = false;
            }
        }
        else
        {
            canMove = true;
        }

        return canMove;

    }

}