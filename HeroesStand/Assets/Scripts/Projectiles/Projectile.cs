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

        SetupCompleted?.Invoke(this, EventArgs.Empty);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit hitTarget = collision.GetComponent<Unit>();
        if (hitTarget != null)
        {
            TargetHitted?.Invoke(this, hitTarget);
        }
    }

    public float Speed => projectileSpeed;
    public Unit Target => target;
    public Unit Unit => unit;
    public float Damage => damage;

    public event EventHandler SetupCompleted;
    public event EventHandler<Unit> TargetHitted;
}
