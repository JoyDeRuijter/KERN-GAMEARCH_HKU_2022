using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchaarAttackBehaviour : BaseAttackBehaviour
{
    public float damage = 13;
    public float fireRate = 0.8f;

    public override void Activate(IEnemy _target)
    {
        Attack(_target,damage,fireRate);
        SpawnParticles();
    }
}
