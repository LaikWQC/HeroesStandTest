using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    private IMoveable moveObject;
    private Vector3 movePosition;
    private bool IsInPosition = true;

    private void Awake()
    {
        moveObject = GetComponent<IMoveable>();
    }

    public void SetPosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        IsInPosition = false;
    }
        
    void Update()
    {
        if(!IsInPosition)
        {
            if (Vector2.Distance(movePosition, transform.position) < moveObject.Speed * Time.fixedDeltaTime)
            {
                IsInPosition = true;
                moveObject.MovementDirection = Vector2.zero;
            }
            else
            {
                moveObject.MovementDirection = (movePosition - transform.position).normalized;
            }
        }        
    }
}
