using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    [SerializeField] private Projectile projectilePf = null;
    private SkillBase skill;

    private void Start()
    {
        skill = GetComponent<SkillBase>();
        skill.DoAttack = CreateProjectile;
    }    

    private void CreateProjectile()
    {
        Projectile projectile = GameObject.Instantiate(projectilePf, transform.position, Quaternion.identity);
        projectile.Setup(skill.Unit, skill.Target, skill.Damage);
    }
}
