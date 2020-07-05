using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrepare 
{
    event EventHandler<EventArguments.TargetForAttackArgs> PrepareStarted;
}
