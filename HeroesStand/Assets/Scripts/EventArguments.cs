using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventArguments
{
    public class HPChangedArgs : EventArgs
    {
        public float CurrentHp;
        public Unit DamageDealer;
    }

    public class TargetForAttackArgs : EventArgs
    {
        public TargetForAttackArgs(Unit unit, Unit target, float damage)
        {
            Unit = unit;
            Target = target;
            Damage = damage;
        }

        public Unit Unit;
        public Unit Target;
        public float Damage;
    }
}
