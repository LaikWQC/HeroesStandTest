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
    }

    protected virtual void OnTargetChanged(object sender, Unit e)
    {
        if (e == null)
        {
            DoWork = SearchForEnemy;
        }
        else
        {
            DoWork = DoNothing;
        }
    }

    virtual protected void Update()
    {
        DoWork();
    }

    private Action DoWork;

    private void DoNothing() { }
    private void SearchForEnemy()
    {
        enemyFinder.FindEnemy();
    }
}
