using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_HitAnyEnemy : MonoBehaviour
{
    private Projectile projectile;
    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.TargetHitted += OnTargetHitted;
    }

    private void OnTargetHitted(object sender, Unit e)
    {
        if(e.Type != projectile.Unit.Type)
        {
            e.TakeDamage(projectile.Damage, projectile.Unit);
            Destroy(gameObject);
        }
    }
}
