using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{

    private float moveSpeed;

    private GameObject body;
    
    private Vector3 position;
    private Vector3Int targetPosition;
    private Vector3Int nextPosition;

    public EnemyController(Vector3 _startPos, Vector3Int _target, float _moveSpeed)
    {
        position = _startPos;
        
        nextPosition = Vector3Int.RoundToInt(_startPos);
        targetPosition = _target;

        moveSpeed = _moveSpeed;
    }

    public void OnStart()
    {
        body = GameObject.Instantiate(Manager.Instance.enemyPrefab,position,Quaternion.identity);
    }

    public void OnUpdate()
    {
        body.transform.position = position;
        MoveTowardsTarget(targetPosition);

        if(Vector3.Distance(position,targetPosition) <= 0.05f)
        {
            Die();
        }
    }

    public void TakeDamage(float _dmg) {}

    private void Die()
    {
        position.Set(2,0,0);
        nextPosition.Set(2,0,0);
    }

    public void MoveTowardsTarget(Vector3Int target)
    {

        position = Vector3.MoveTowards(position,nextPosition,moveSpeed*Time.deltaTime);

        if(Vector3.Distance(position,nextPosition) <= 0.05f) {

            if(Mathf.Abs(target.x-position.x) >= Mathf.Abs(target.z-position.z)) {

                if(target.x > position.x) {
                    if(CanMove("Right")) {
                        Move("Right");
                    }
                    else {
                        if(target.z < position.z) {
                            if(CanMove("Down")) {
                                Move("Down");
                            }
                        }
                        else if(target.z > position.z) {
                            if(CanMove("Up")) {
                                Move("Up");
                            }
                        }
                    }
                }
                else if(target.x < position.x) {
                    if(CanMove("Left")) {
                        Move("Left");
                    }
                    else {
                        if(target.z < position.z) {
                            if(CanMove("Down")) {
                                Move("Down");
                            }
                        }
                        else if(target.z > position.z) {
                            if(CanMove("Up")) {
                                Move("Up");
                            }
                        }
                    }
                }
            }

            if(Mathf.Abs(target.x-position.x) < Mathf.Abs(target.z-position.z)) {

                if(target.z < position.z) {
                    if(CanMove("Down")) {
                        Move("Down");
                    }
                    else {
                        if(target.x > position.x) {
                            if(CanMove("Right")) {
                                Move("Right");
                            }
                        }
                        else if(target.x < position.x) {
                            if(CanMove("Left")) {
                                Move("Left");
                            }
                        }
                    }
                }
                else if(target.z > position.z) {
                    if(CanMove("Up")) {
                        Move("Up");
                    }
                    else {
                        if(target.x > position.x) {
                            if(CanMove("Right")) {
                                Move("Right");
                            }
                        }
                        else if(target.x < position.x) {
                            if(CanMove("Left")) {
                                Move("Left");
                            }
                        }
                    }
                }
            }

        }

    }

    private void Move(string dir)
    {

        int x = nextPosition.x;
        int z = nextPosition.z;

        switch(dir)
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

    private bool CanMove(string dir)
    {

        bool canMove = true;

        int x = nextPosition.x;
        int z = nextPosition.z;

        switch(dir)
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

            if(Manager.Instance.level[pos].type == TileType.WALL || Manager.Instance.level[pos].isOccupied)
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