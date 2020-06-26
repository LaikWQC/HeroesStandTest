using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour_MoveStraight : IUnitBehaviour
{
    private Unit unit;
    private EnemyFinder enemyFinder;
    private Vector3 moveDirection;

    public IdleBehaviour_MoveStraight(Unit unit, Vector3 moveDirection)
    {
        this.unit = unit;
        enemyFinder = unit.GetComponent<EnemyFinder>();
        this.moveDirection = moveDirection;
    }

    public void UpdateBehavour()
    {
        if (enemyFinder.FindEnemy())
            unit.MovementDirection = Vector3.zero;
        else
            unit.MovementDirection = moveDirection.normalized;
    }
}
