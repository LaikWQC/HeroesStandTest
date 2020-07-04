using System;
using UnityEngine;

public class BattleBehaviour_MoveToTarget : MonoBehaviour
{
    private Unit unit;
    private IMoveable moveObject;

    private void Awake()
    {
        unit = GetComponentInParent<Unit>();
        unit.TargetChanged += OnTargetChanged;
        moveObject = GetComponentInParent<IMoveable>();

        DoWork = DoNothing;
    }

    private void Update()
    {
        DoWork();
    }

    private void OnTargetChanged(object sender, Unit e)
    {
        if (e != null)
            DoWork = ChaseTarget;
        else
            DoWork = DoNothing;
    }

    private Action DoWork;

    private void DoNothing() { }
    private void ChaseTarget()
    {
        Vector3 targetDirection = unit.Target.Position - unit.Position;

        if (targetDirection.magnitude > unit.AttackRange)
            moveObject.MovementDirectionOverride = targetDirection.normalized;
        else
            moveObject.MovementDirectionOverride = Vector3.zero;
    }    
}
