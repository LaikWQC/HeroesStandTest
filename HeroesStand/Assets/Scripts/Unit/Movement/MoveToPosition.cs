using System;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    private IMoveable moveObject;
    private Vector3 movePosition;
    private Action moveAction;

    private void Awake()
    {
        moveObject = GetComponent<IMoveable>();
        moveObject.MovementPositionChanged += OnPositionChanged;
        moveAction = Stay;
    }

    private void OnPositionChanged(object sender, Vector3? e)
    {
        if (e != null)
        {
            movePosition = e.Value;
            moveAction = Move;
        }
        else
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
            moveAction = Stay;
            moveObject.MovementDirection = Vector2.zero;
        }
        else
        {
            moveObject.MovementDirection = (movePosition - transform.position).normalized;
        }
    }
}
