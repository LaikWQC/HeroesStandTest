using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IMoveable
{
    private float currentHp;
    [SerializeField]
    private float maxHp = 20;
    [SerializeField]
    private float speed = 2;
    private Vector3 movementDirection;

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
            OnMovementDirectionChanged?.Invoke(this, value);
        }
    }

    public float Speed => speed;

    public event EventHandler<Vector3> OnMovementDirectionChanged;
}
