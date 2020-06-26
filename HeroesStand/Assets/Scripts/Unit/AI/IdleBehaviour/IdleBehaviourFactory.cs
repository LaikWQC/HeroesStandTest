using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IdleBehaviourFactory 
{
    public static IUnitBehaviour GetBahaviour(Unit unit, IdleBehaviourType type)
    {
        switch(type)
        {
            default:
            case IdleBehaviourType.Hold:
                return new IdleBehaviour_HoldPosition(unit);
            case IdleBehaviourType.MoveLeft:
                return new IdleBehaviour_MoveStraight(unit, Vector2.left);
            case IdleBehaviourType.MoveRight:
                return new IdleBehaviour_MoveStraight(unit, Vector2.right);
        }
    }
}
