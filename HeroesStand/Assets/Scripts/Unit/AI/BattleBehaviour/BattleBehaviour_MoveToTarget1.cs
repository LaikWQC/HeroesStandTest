using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBehaviour_MoveToTarget : IUnitBehaviour
{
    private Unit unit;

    public BattleBehaviour_MoveToTarget(Unit unit)
    {
        this.unit = unit;
    }

    public void UpdateBehavour()
    {
        if (unit.Target == null) return;

        Vector3 targetDirection = unit.Target.Position - unit.Position;

        if (targetDirection.magnitude > unit.AttackRange)
            unit.MovementDirection = targetDirection.normalized;
        else
            unit.MovementDirection = Vector3.zero;
    }
}
