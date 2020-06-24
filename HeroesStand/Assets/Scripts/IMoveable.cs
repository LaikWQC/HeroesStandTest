using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    Vector3 MovementDirection { get; set; }
    float Speed { get; }
    event EventHandler<Vector3> OnMovementDirectionChanged;
}
