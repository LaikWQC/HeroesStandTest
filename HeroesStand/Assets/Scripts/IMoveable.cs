using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    /// <summary>
    /// Вектор направления движения
    /// </summary>
    Vector3 MovementDirection { get; set; }

    /// <summary>
    /// Вектор направления движения (изменение отменяет передвижение к точке)
    /// </summary>
    Vector3 MovementDirectionOverride { get; set; }

    /// <summary>
    /// Точка, до которой надо дойти
    /// </summary>
    Vector3? MovementPosition { get; set; }

    float Speed { get; }

    event EventHandler<Vector3> MovementDirectionChanged;
    event EventHandler<Vector3?> MovementPositionChanged;
}
