using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDecorator
{
    
    public float Health { get; set; }
    public float Damage { get; set; }

    public EnemyDecorator(float _health, float _dmg)
    {
        Health = _health;
        Damage = _dmg;
    }

    public IEnemy Decorate(IEnemy _e)
    {
        _e.Health += Health;
        _e.Damage += Damage;
        return _e;
    }

}
