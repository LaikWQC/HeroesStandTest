using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    private IMoveable moveObject;
    private Vector3 movePosition;
    private Action moveAction;

    private void Awake()
    {
        moveObject = GetComponent<IMoveable>();
        moveAction = Stay;
    }

    public void SetPosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        moveAction = Move;
    }

    public void StopMoving()
    {
        moveAction = Stay;
    }
        
    void Update()
    {       
        moveAction();
    }

    private void Stay() { }
    private void Move()
    {
        if (Vector2.Distance(movePosition, transform.position) < moveObject.Speed * Time.fixedDeltaTime)
        {
            StopMoving();
            moveObject.MovementDirection = Vector2.zero;
        }
        else
        {
            moveObject.MovementDirection = (movePosition - transform.position).normalized;
        }
    }
}
