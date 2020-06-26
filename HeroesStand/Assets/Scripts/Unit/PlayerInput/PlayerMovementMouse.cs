using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour
{    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 movePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movePosition.z = 0;
            GetComponent<IMoveable>().MovementPosition = movePosition;
        }        
    }
}
