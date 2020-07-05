using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator_MoveInDirection : MonoBehaviour
{
    private Projectile projectile;
    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.SetupCompleted += OnSetupComplited;
    }

    private void OnSetupComplited(object sender, Unit target)
    {
        GetComponent<IMoveable>().MovementDirection = (target.Position - transform.position).normalized;
    }
}
