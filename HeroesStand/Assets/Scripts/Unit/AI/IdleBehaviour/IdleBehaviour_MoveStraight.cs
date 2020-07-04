using UnityEngine;
using UnityEngine.EventSystems;

public class IdleBehaviour_MoveStraight : IdleBehaviour
{
    private IMoveable moveObject;
    [SerializeField] private MoveDirection moveDirection = MoveDirection.None;
    private Vector3 moveVector;

    protected override void Awake()
    {
        base.Awake();
        moveObject = GetComponentInParent<IMoveable>();
        switch(moveDirection)
        {
            case MoveDirection.Up:
                moveVector = Vector2.up;
                break;
            case MoveDirection.Down:
                moveVector = Vector2.down;
                break;
            case MoveDirection.Left:
                moveVector = Vector2.left;
                break;
            case MoveDirection.Right:
                moveVector = Vector2.right;
                break;
            case MoveDirection.None:
            default:
                moveVector = Vector2.zero;
                break;
        }
    }

    protected override void Update()
    {
        base.Update();
        moveObject.MovementDirection = moveVector;
    }
}
