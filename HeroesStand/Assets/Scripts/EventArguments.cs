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
}
