using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee : MonoBehaviour
{
    private void Start()
    {
        GetComponent<IAttack>().AttackStarted += OnAttackStarted;
    }

    private void OnAttackStarted(object sender, EventArguments.TargetForAttackArgs e)
    {
        e.Target.TakeDamage(e.Damage, e.Unit);
    }
}
