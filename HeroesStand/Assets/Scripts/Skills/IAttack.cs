using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    event EventHandler<EventArguments.TargetForAttackArgs> AttackStarted;
}
