using UnityEngine;

public class BattleBehaviour_MoveToTarget : IUnitBehaviour
{
    private Unit unit;
    private IMoveable moveObject;

    public BattleBehaviour_MoveToTarget(Unit unit)
    {
        this.unit = unit;
        moveObject = unit.GetComponent<IMoveable>();
    }

    public void UpdateBehavour()
    {
        if (unit.Target == null) return;

        Vector3 targetDirection = unit.Target.Position - unit.Position;

        if (targetDirection.magnitude > unit.AttackRange)
            moveObject.MovementDirectionOverride = targetDirection.normalized;
        else
            moveObject.MovementDirectionOverride = Vector3.zero;
    }
}
