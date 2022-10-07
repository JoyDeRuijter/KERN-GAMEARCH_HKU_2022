using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteenAttackBehaviour : BaseAttackBehaviour
{
    new public float damage = 20;
    new public float fireRate = 4;

    public SteenAttackBehaviour(Transform _towerTransform)
    {
        towerTransform = _towerTransform;
    }

    public override void SpawnParticles()
    {
        GameObject particleEffect = Resources.Load<GameObject>("Prefabs/ParticleEffect");
        GameObject spawnedEffect = Object.Instantiate(particleEffect, towerTransform);
        Object.Destroy(spawnedEffect, 2f);
    }
}
