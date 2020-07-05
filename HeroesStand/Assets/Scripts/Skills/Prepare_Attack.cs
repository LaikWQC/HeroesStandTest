using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prepare_Attack : MonoBehaviour, IAttack
{
    private void Awake()
    {
        GetComponent<IPrepare>().PrepareStarted += OnPrepareStarted;
    }

    private void OnPrepareStarted(object sender, EventArguments.TargetForAttackArgs e)
    {
        AttackStarted?.Invoke(this, e);
    }

    public event EventHandler<EventArguments.TargetForAttackArgs> AttackStarted;
}
