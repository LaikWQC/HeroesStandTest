using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour, IPrepare
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
                PrepareStarted?.Invoke(this, new EventArguments.TargetForAttackArgs(unit, target, damage));
                beforeNextAttack = attackDelay;
            }
        }
    }

    public event EventHandler<EventArguments.TargetForAttackArgs> PrepareStarted;
}
