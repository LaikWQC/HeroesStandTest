using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, ISpeed
{
    [SerializeField] private float projectileSpeed = 10.0f;
    private Unit unit;
    private Unit target;
    private float damage;

    public void Setup(Unit unit, Unit target, float damage)
    {
        this.unit = unit;
        this.target = target;
        this.damage = damage;

        SetupCompleted?.Invoke(this, target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit hitTarget = collision.GetComponent<Unit>();
        if (hitTarget != null)
        {
            if (hitTarget == target)
                MainTargetHitted?.Invoke(this, new EventArguments.TargetForAttackArgs(unit, hitTarget, damage));
            else
                AnotherTargetHitted?.Invoke(this, new EventArguments.TargetForAttackArgs(unit, hitTarget, damage));
        }
    }

    public float Speed => projectileSpeed;

    public event EventHandler<Unit> SetupCompleted;
    public event EventHandler<EventArguments.TargetForAttackArgs> MainTargetHitted;
    public event EventHandler<EventArguments.TargetForAttackArgs> AnotherTargetHitted;
}
