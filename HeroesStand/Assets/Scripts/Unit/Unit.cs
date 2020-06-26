using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IMoveable
{
    [SerializeField] private UnitType type = UnitType.Enemy;
    private float currentHp;
    [SerializeField] private int maxHp = 20;
    [SerializeField] [Range(0.0f, 5.0f)] private float speed = 2.0f;
    [SerializeField] private float visionRadius = 4.0f;
    private Vector3 movementDirection;
    private Vector3? movementPosition;
    private float? attackRange;
    private Unit target;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public void SetAttackRange(float range)
    {
        if (attackRange == null || range < attackRange)
            attackRange = range;
    }

    public void TakeDamage(float damage)
    {
        if(currentHp > 0)
        {
            currentHp -= damage;
            if (currentHp <= 0)
                Die();
        }        
    }

    private void Die()
    {
        Died?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }

    public Vector3 MovementDirection
    {
        get => movementDirection;
        set
        {
            if(movementDirection!=value)
            {
                movementDirection = value;
                MovementDirectionChanged?.Invoke(this, value);
            }            
        }
    }

    public Vector3 MovementDirectionOverride
    {
        get => movementDirection;
        set
        {
            MovementDirection = value;
            MovementPosition = null;
        }
    }

    public Vector3? MovementPosition
    {
        get => movementPosition;
        set
        {
            if (movementPosition != value)
            {
                movementPosition = value;
                MovementPositionChanged?.Invoke(this, value);
            }            
        }
    }

    public Unit Target
    {
        get => target;
        set
        {
            target = value;
            if (target != null) target.Died += (obj, e) => Target = null;
            TargetChanged?.Invoke(this, value);
        }
    }

    public float Speed => speed;
    public float VisionRadius => visionRadius;
    public UnitType Type => type;
    public Vector3 Position => transform.position;
    public float AttackRange => attackRange ?? 1.5f;

    public event EventHandler<Unit> TargetChanged;
    public event EventHandler<Vector3> MovementDirectionChanged;
    public event EventHandler<Vector3?> MovementPositionChanged;
    public event EventHandler Died;
}
