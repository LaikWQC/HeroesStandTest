﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    private Vector3 velocityVector;
    private IMoveable moveObject;

    private void Awake()
    {
        moveObject = GetComponent<IMoveable>();
        moveObject.OnMovementDirectionChanged += (sender, direction) => SetVelocity(direction);
    }

    public void SetVelocity(Vector3 direction)
    {
        velocityVector = direction;
    }

    private void Update()
    {
        transform.position += velocityVector * moveObject.Speed * Time.deltaTime;
    }
}
