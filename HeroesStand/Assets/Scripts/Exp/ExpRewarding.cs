using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpRewarding : MonoBehaviour
{
    [SerializeField] private float expForDamage = 10.0f;
    [SerializeField] private float expForKill = 10.0f;
    private Unit unit;
    private float remaningExp;
    private float HPBeforeThis;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        unit.HpChanged += OnHpChanged;
        unit.Died += OnDeath;

        remaningExp = expForDamage;
        HPBeforeThis = unit.MaxHp;
    }

    private void OnDeath(object sender, Unit e)
    {
        Reward(expForKill, e);
    }

    private void OnHpChanged(object sender, EventArguments.HPChangedArgs e)
    {
        if (e.CurrentHp < 0) e.CurrentHp = 0;

        if(e.CurrentHp < HPBeforeThis)
        {
            float ratio = (HPBeforeThis - e.CurrentHp) / HPBeforeThis;
            float exp = remaningExp * ratio;
            Reward(exp, e.DamageDealer);
            remaningExp -= exp;
        }
        HPBeforeThis = e.CurrentHp;
    }

    private void Reward(float exp, Unit damageDealer)
    {
        if (damageDealer != null)
            damageDealer.GetComponent<ExpCollecting>()?.GrantExp(exp);
    }
}
