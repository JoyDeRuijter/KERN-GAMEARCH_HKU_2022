using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttackBehaviour
{
    public float damage;
    public float fireRate;
    public Transform towerTransform;

    public virtual void Attack(EnemyController _target)
    {
        float timeLeft = fireRate;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            _target.TakeDamage(damage);
            SpawnParticles();
        }
    }
    public abstract void SpawnParticles();
}
