using System;
using UnityEngine;

public class IdleBehaviour_HoldPosition : IdleBehaviour
{
    private IMoveable moveObject;
    private Vector3 startingPosition;

    protected override void Awake()
    {
        base.Awake();
        moveObject = GetComponentInParent<IMoveable>();
        startingPosition = transform.position;
    }

    protected override void OnTargetChanged(object sender, Unit e)
    {
        base.OnTargetChanged(sender, e);
        if(e == null)
        {
            moveObject.MovementPosition = startingPosition;
        }
    }
}
