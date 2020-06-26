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
    private float attackRange =1.5f;
    private Unit target;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public Vector3 MovementDirection
    {
        get => movementDirection;
        set
        {
            movementDirection = value;
            MovementDirectionChanged?.Invoke(this, value);
        }
    }

    public Unit Target
    {
        get => target;
        set
        {
            target = value;
            TargetChanged?.Invoke(this, value);
        }
    }

    public float Speed => speed;
    public float VisionRadius => visionRadius;
    public UnitType Type => type;
    public Vector3 Position => transform.position;
    public float AttackRange => attackRange;

    public event EventHandler<Unit> TargetChanged;
    public event EventHandler<Vector3> MovementDirectionChanged;
}
