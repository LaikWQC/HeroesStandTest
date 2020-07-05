using UnityEngine;

public class PlayerMovementKeys : MonoBehaviour
{
    private IMoveable moveObject;

    private void Awake()
    {
        moveObject = GetComponent<IMoveable>();
    }

    private void Update()
    {
        Vector3 moveVector = new Vector3(0, 0);
        if (Input.GetKey(KeyCode.W)) moveVector.y++;
        if (Input.GetKey(KeyCode.S)) moveVector.y--;
        if (Input.GetKey(KeyCode.A)) moveVector.x--;
        if (Input.GetKey(KeyCode.D)) moveVector.x++;

        if(moveVector!= Vector3.zero)
            moveObject.MovementDirectionOverride = moveVector.normalized;
    }
}
