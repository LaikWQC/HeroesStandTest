using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator_MoveInDirection : MonoBehaviour
{
    private Missile missile;
    private void Awake()
    {
        missile = GetComponent<Missile>();
        missile.SetupCompleted += OnSetupComplited;
    }

    private void OnSetupComplited(object sender, EventArgs e)
    {
        GetComponent<IMoveable>().MovementDirection = (missile.Target.Position - transform.position).normalized;
    }
}
