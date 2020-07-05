using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour
{    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<IMoveable>().MovementPosition = Utils.MousePosition();
        }        
    }
}
