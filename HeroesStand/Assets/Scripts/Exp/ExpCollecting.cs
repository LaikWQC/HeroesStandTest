using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollecting : MonoBehaviour
{
    private Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public void GrantExp(float exp)
    {
        GameManager.Inst.SetExp(unit, exp);
    }
}
