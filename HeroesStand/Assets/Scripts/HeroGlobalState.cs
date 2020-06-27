using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGlobalState 
{
    public HeroGlobalState()
    {
        IsAlive = true;
        Exp = 0;
    }

    public bool IsAlive { get; set; }
    public float Exp { get; set; }
}
