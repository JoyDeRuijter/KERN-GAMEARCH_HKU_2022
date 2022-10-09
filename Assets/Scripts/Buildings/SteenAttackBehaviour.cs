using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteenAttackBehaviour : BaseAttackBehaviour
{
    public float damage = 20;
    public float fireRate = 1.2f;

    public override void Activate(IEnemy _target)
    {
        Attack(_target,damage,fireRate);
        SpawnParticles();
    }
}
