using UnityEngine;

public class HPIndicator : MonoBehaviour
{
    private Unit unit;
    [SerializeField] private Transform Bar;

    private void Awake()
    {
        unit = GetComponentInParent<Unit>();
        unit.HpChanged += OnHpChanged;
    }

    private void OnHpChanged(object sender, float e)
    {
        if (e < 0) e = 0;
        Bar.localScale = new Vector3(e / unit.MaxHp, 1f);
    }
}
