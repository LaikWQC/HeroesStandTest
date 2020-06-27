using UnityEngine;

public class IdleBehaviour_HoldPosition : IUnitBehaviour
{
    private IMoveable moveObject;
    private IEnemyFinder enemyFinder;
    private Vector3 startingPosition;

    public IdleBehaviour_HoldPosition(Unit unit)
    {
        moveObject = unit.GetComponent<IMoveable>();
        startingPosition = unit.Position;
        enemyFinder = unit.GetComponentInChildren<IEnemyFinder>();
    }

    public void UpdateBehavour()
    {
        enemyFinder.FindEnemy();

        moveObject.MovementPosition = startingPosition;
    }
}
