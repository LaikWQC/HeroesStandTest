using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class EnemyFinder : MonoBehaviour
{
    [SerializeField] VisionRange visionRange = null;
    protected Unit unit;
    protected List<Unit> enemies;
    protected Unit target;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        enemies = new List<Unit>();

        var range = Instantiate(visionRange, transform);
        range.SetRadius(unit.VisionRadius);
        range.UnitEnter += OnUnitEnter;
        range.UnitLeave += OnUnitLeave;
    }

    private void OnUnitEnter(object sender, Unit e)
    {
        if (e.Type != unit.Type)
            enemies.Add(e);
    }

    private void OnUnitLeave(object sender, Unit e)
    {
        if (e.Type != unit.Type)
            enemies.Remove(e);
    }

    public virtual bool FindEnemy()
    {
        if (target != null)
        {
            unit.Target = target;
            return true;
        }
        return false;
    }
}
