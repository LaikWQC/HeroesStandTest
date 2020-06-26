using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour_HoldPosition : IUnitBehaviour
{
    private Transform transform;
    private EnemyFinder enemyFinder;
    private MoveToPosition moveToPos;
    private Vector3 startingPosition;

    public IdleBehaviour_HoldPosition(Unit unit)
    {
        transform = unit.transform;
        startingPosition = transform.position;
        enemyFinder = unit.GetComponent<EnemyFinder>();
        moveToPos = unit.GetComponent<MoveToPosition>();
    }

    public void UpdateBehavour()
    {
        if(enemyFinder.FindEnemy())
        {
            moveToPos.StopMoving();
        }
        else
        {
            moveToPos?.SetPosition(startingPosition);
        }        
    }
}
