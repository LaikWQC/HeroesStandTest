using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager inst;
    private Dictionary<Unit, HeroGlobalState> heroes;

    void Awake()
    {
        inst = this;
        heroes = new Dictionary<Unit, HeroGlobalState>();
    }

    public void SetExp(Unit unit, float exp)
    {
        if (heroes.ContainsKey(unit))
            heroes[unit].Exp += exp;
    }

    public void HeroSubscribe(Unit unit, string name)
    {
        heroes.Add(unit, new HeroGlobalState(name));
        unit.Died += (obj, e) => heroes[unit].IsAlive = false;
    }

    public static GameManager Inst => inst;
}
