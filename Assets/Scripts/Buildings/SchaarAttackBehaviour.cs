using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchaarAttackBehaviour : BaseAttackBehaviour
{
    public float damage = 7;
    public float fireRate = 4;

    public override void Activate(IEnemy _target)
    {
        Attack(_target,damage,fireRate);
        SpawnParticles();
    }
}
