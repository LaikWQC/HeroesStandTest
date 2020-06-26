using UnityEngine;

public class IdleBehaviour_MoveStraight : IUnitBehaviour
{
    private IMoveable moveObject;
    private EnemyFinder enemyFinder;
    private Vector3 moveDirection;

    public IdleBehaviour_MoveStraight(Unit unit, Vector3 moveDirection)
    {
        moveObject = unit.GetComponent<IMoveable>();
        enemyFinder = unit.GetComponent<EnemyFinder>();
        this.moveDirection = moveDirection.normalized;
    }

    public void UpdateBehavour()
    {
        enemyFinder.FindEnemy();
        
        moveObject.MovementDirectionOverride = moveDirection;
    }
}
