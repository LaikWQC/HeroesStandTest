using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class VisionRange_EnemiesOnly : MonoBehaviour, IVision
{
    private List<Unit> enemies;
    private List<Unit> alies;
    private UnitType type;

    private void Awake()
    {
        enemies = new List<Unit>();
        alies = new List<Unit>();
        Unit unit = GetComponentInParent<Unit>();
        type = unit.Type;
        GetComponent<CircleCollider2D>().radius = unit.VisionRadius;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if (unit != null)
        {
            if (unit.Type != type)
                enemies.Add(unit);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if (unit != null)
        {
            if (unit.Type != type)
                enemies.Remove(unit);
        }
    }
    public List<Unit> Enemies => enemies;
    public List<Unit> Alies => alies;
}
