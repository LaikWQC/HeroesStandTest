using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    [SerializeField] IdleBehaviourType idleBehaviourType = IdleBehaviourType.Hold;
    private Unit unit;
    private IUnitBehaviour unitBehaviour;
    private IUnitBehaviour idleBehaviour;
    private IUnitBehaviour battleBehaviour;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        unit.TargetChanged += OnTargetChanged;
        idleBehaviour = IdleBehaviourFactory.GetBahaviour(unit, idleBehaviourType);
        battleBehaviour = new BattleBehaviour_MoveToTarget(unit);

        unitBehaviour = idleBehaviour;
    }

    private void OnTargetChanged(object sender, Unit e)
    {
        if (e == null)
            unitBehaviour = idleBehaviour;
        else
            unitBehaviour = battleBehaviour;
    }

    private void Update()
    {
        unitBehaviour.UpdateBehavour();
    }
}
