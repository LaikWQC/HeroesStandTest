using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour
{
    private Vector3 velocityVector;
    private Rigidbody2D rg;
    private IMoveable moveObject;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        moveObject = GetComponent<IMoveable>();
        moveObject.MovementDirectionChanged += (sender, direction) => SetVelocity(direction);
    }

    public void SetVelocity(Vector3 direction)
    {
        velocityVector = direction;
    }

    private void FixedUpdate()
    {
        rg.velocity = velocityVector * moveObject.Speed;
    }
}
