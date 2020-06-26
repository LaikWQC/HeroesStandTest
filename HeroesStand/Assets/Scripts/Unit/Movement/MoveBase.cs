using System;
using UnityEngine;

public class MoveBase : MonoBehaviour, IMoveable
{
    private Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    private Vector3 movementDirection;
    private Vector3? movementPosition;

    public Vector3 MovementDirection
    {
        get => movementDirection;
        set
        {
            if (movementDirection != value)
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

    public float Speed => unit.Speed;

    public event EventHandler<Vector3> MovementDirectionChanged;
    public event EventHandler<Vector3?> MovementPositionChanged;
}
