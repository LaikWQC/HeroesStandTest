using System;
using UnityEngine;

[RequireComponent(typeof(MoveBase))]
public class Unit : MonoBehaviour
{
    [SerializeField] private UnitType type = UnitType.Enemy;
    private float currentHp;
    [SerializeField] private int maxHp = 20;
    [SerializeField] [Range(0.0f, 5.0f)] private float speed = 2.0f;
    [SerializeField] private float visionRadius = 4.0f;
    private float? attackRange;
    private Unit target;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public void SetAttackRange(float range)
    {
        if (attackRange == null || range < attackRange)
            attackRange = range;
    }

    public void TakeDamage(float damage)
    {
        if(currentHp > 0)
        {
            currentHp -= damage;
            HpChanged?.Invoke(this, currentHp);
            if (currentHp <= 0)
                Die();
        }        
    }

    private void Die()
    {
        Died?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }

    public Unit Target
    {
        get => target;
        set
        {
            target = value;
            if (target != null) target.Died += (obj, e) => Target = null;
            TargetChanged?.Invoke(this, value);
        }
    }

    public float Speed => speed;
    public float VisionRadius => visionRadius;
    public UnitType Type => type;
    public Vector3 Position => transform.position;
    public float AttackRange => attackRange ?? 1.5f;
    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;

    public event EventHandler<Unit> TargetChanged;
    public event EventHandler<float> HpChanged;
    public event EventHandler Died;
}
