using System;
using UnityEngine;

public class Attack_Ranged : MonoBehaviour
{
    [SerializeField] private Projectile projectilePf = null;

    private void Start()
    {
        GetComponent<IAttack>().AttackStarted += OnAttackStarted;
    }

    private void OnAttackStarted(object sender, EventArguments.TargetForAttackArgs e)
    {
        Projectile projectile = GameObject.Instantiate(projectilePf, transform.position, Quaternion.identity);
        projectile.Setup(e.Unit, e.Target, e.Damage);
    }
}
