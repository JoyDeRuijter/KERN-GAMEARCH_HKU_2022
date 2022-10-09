using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackBehaviour
{
    public Transform towerTransform;

    public virtual void Activate(IEnemy _target) {}

    protected void Attack(IEnemy _target,float _dmg,float _fireRate)
    {
        float timeLeft = _fireRate;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            _target.TakeDamage(_dmg);
            SpawnParticles();
        }
    }
    protected void SpawnParticles()
    {
        GameObject particleEffect = Resources.Load<GameObject>("ParticleEffect");
        GameObject spawnedEffect = Object.Instantiate(particleEffect, towerTransform);
        Object.Destroy(spawnedEffect, 2f);
    }
}
