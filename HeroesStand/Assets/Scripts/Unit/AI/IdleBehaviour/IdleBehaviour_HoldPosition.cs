using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour_HoldPosition : IUnitBehaviour
{
    private IMoveable moveObject;
    private EnemyFinder enemyFinder;
    private Vector3 startingPosition;

    public IdleBehaviour_HoldPosition(Unit unit)
    {
        moveObject = unit.GetComponent<IMoveable>();
        startingPosition = unit.Position;
        enemyFinder = unit.GetComponent<EnemyFinder>();
    }

    public void UpdateBehavour()
    {
        enemyFinder.FindEnemy();

        moveObject.MovementPosition = startingPosition;
    }
}
