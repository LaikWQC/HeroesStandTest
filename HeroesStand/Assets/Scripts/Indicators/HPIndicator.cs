using System;
using UnityEngine;

public class HPIndicator : MonoBehaviour
{
    private Unit unit;
    [SerializeField] private Transform Fill = null;

    private void Awake()
    {
        unit = GetComponentInParent<Unit>();
        unit.HpChanged += OnHpChanged;
    }

    private void OnHpChanged(object sender, EventArguments.HPChangedArgs e)
    {
        Fill.localScale = new Vector3(Mathf.Clamp(e.CurrentHp / unit.MaxHp, 0, 1), 1f);
    }
}
