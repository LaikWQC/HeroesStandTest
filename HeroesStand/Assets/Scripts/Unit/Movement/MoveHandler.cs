using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    private Vector3 movementDirection;
    private Vector3 movementPosition;
    private Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
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

    public float Speed => unit.Speed;

    public event EventHandler<Vector3> MovementDirectionChanged;
}
