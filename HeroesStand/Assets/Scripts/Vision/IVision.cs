using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVision 
{
    List<Unit> Enemies { get; }
    List<Unit> Alies { get; }
}
