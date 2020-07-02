using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_HitAnyEnemy : MonoBehaviour
{
    private Missile missile;
    private void Awake()
    {
        missile = GetComponent<Missile>();
        missile.TargetHitted += OnTargetHitted;
    }

    private void OnTargetHitted(object sender, Unit e)
    {
        if(e.Type != missile.Unit.Type)
        {
            e.TakeDamage(missile.Damage, missile.Unit);
            Destroy(gameObject);
        }
    }
}
