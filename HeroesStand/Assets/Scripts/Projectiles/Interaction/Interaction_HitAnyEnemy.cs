using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_HitAnyEnemy : MonoBehaviour
{
    private void Awake()
    {
        Projectile projectile = GetComponent<Projectile>();
        projectile.MainTargetHitted += OnTargetHitted;
        projectile.AnotherTargetHitted += OnTargetHitted;
    }

    private void OnTargetHitted(object sender, EventArguments.TargetForAttackArgs e)
    {
        if(e.Target.Type != e.Unit.Type)
        {
            e.Target.TakeDamage(e.Damage, e.Unit);
            Destroy(gameObject);
        }
    }
}
