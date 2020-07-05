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
        Vector3 direction = target.Position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GetComponent<IMoveable>().MovementDirection = direction.normalized;
    }
}
