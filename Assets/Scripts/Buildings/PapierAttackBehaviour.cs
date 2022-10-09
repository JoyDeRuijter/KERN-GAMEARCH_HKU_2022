using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapierAttackBehaviour : BaseAttackBehaviour
{
    public float damage = 7;
    public float fireRate = 0.3f;

    public override void Activate(IEnemy _target)
    {
        Attack(_target,damage,fireRate);
        SpawnParticles();
    }
}
