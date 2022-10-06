using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackBehaviour
{
    float damage;
    float fireRate;
    float attackRange;

    //Stack of enemies to detect within range
    //Stack<Enemy> enemies;

    BaseAttackBehaviour(float _damage, float _fireRate, float _attackRange)
    {
        damage = _damage;
        fireRate = _fireRate;
        attackRange = _attackRange;
    }

    void RangeCheck()
    {
        //cycle through enemies
        //if is within range do attack
        //Attack();
    }

    public virtual void Attack()
    {

    }
}
