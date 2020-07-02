using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    [SerializeField] private float damage = 0;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float range = 1.2f;
    private float attackDelay;
    private Unit target;
    private Unit unit;
    private float beforeNextAttack = 0.0f;

    private void Awake()
    {
        unit = GetComponentInParent<Unit>();
        unit.TargetChanged += OnTargetChanged;
        unit.SetAttackRange(range);

        attackDelay = 1 / attackSpeed;

        PrepareAttack = PrepareAttackDefault;
        DoAttack = DoAttackDefault;
    }

    private void OnTargetChanged(object sender, Unit e)
    {
        target = e;
    }

    private void Update()
    {
        beforeNextAttack -= Time.deltaTime;
        if (beforeNextAttack < 0) beforeNextAttack = 0;

        if (target != null && beforeNextAttack == 0)
        {
            if (Vector2.Distance(target.Position, transform.position) <= range)
            {
                PrepareAttack();
                beforeNextAttack = attackDelay;
            }
        }
    }

    public Action PrepareAttack { get; set; }
    public Action DoAttack { get; set; }

    public Unit Unit => unit;
    public Unit Target => target;
    public float Damage => damage;

    private void PrepareAttackDefault()
    {
        DoAttack();
    }

    private void DoAttackDefault()
    {
        target.TakeDamage(damage, unit);
    }
}
