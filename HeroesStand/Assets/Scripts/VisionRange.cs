using System;
using UnityEngine;

public class VisionRange : MonoBehaviour
{
    public void SetRadius(float radius)
    {
        GetComponent<CircleCollider2D>().radius = radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if (unit != null)
        {
            UnitEnter?.Invoke(this, unit);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if (unit != null)
        {
            UnitLeave?.Invoke(this, unit);
        }
    }

    public event EventHandler<Unit> UnitEnter;
    public event EventHandler<Unit> UnitLeave;
}
