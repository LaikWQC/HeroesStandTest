using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IdleBehaviour : MonoBehaviour
{
    private IEnemyFinder enemyFinder;

    virtual protected void Awake()
    {
        Unit unit = GetComponentInParent<Unit>();
        enemyFinder = unit.GetComponentInChildren<IEnemyFinder>();
        unit.TargetChanged += OnTargetChanged;

        DoWork = SearchForEnemy;
        ActionOnUpdate = DoWork;
    }

    protected virtual void OnTargetChanged(object sender, Unit e)
    {
        if (e == null)
        {
            ActionOnUpdate = DoWork;
        }
        else
        {
            ActionOnUpdate = DoNothing;
        }
    }

    void Update()
    {
        ActionOnUpdate();
    }

    private Action ActionOnUpdate { get; set; }
    protected Action DoWork { get; set; }

    private void DoNothing() { }
    private void SearchForEnemy()
    {
        enemyFinder.FindEnemy();
    }
}
