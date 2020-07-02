using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGlobalState 
{
    public HeroGlobalState(string name)
    {
        Name = name;
        IsAlive = true;
        Exp = 0;
    }

    public string Name { get; set; }
    public bool IsAlive { get; set; }
    public float Exp { get; set; }
}
