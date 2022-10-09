using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapierAttackBehaviour : BaseAttackBehaviour
{
    public float damage = 4;
    public float fireRate = 2;

    public override void Activate(IEnemy _target)
    {
        Attack(_target,damage,fireRate);
        SpawnParticles();
    }
}
