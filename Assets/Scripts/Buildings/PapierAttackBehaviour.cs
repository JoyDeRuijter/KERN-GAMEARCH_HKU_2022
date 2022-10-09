using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapierAttackBehaviour : BaseAttackBehaviour
{
    new public float damage = 5;
    new public float fireRate = 2;

    public override void SpawnParticles()
    {
        GameObject particleEffect = Resources.Load<GameObject>("ParticleEffect");
        GameObject spawnedEffect = Object.Instantiate(particleEffect, towerTransform);
        Object.Destroy(spawnedEffect, 2f);
    }
}
