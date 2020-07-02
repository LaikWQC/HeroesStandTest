using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    [SerializeField] private Missile missilePf = null;
    private SkillBase skill;

    private void Start()
    {
        skill = GetComponent<SkillBase>();
        skill.DoAttack = CreateMissile;
    }    

    private void CreateMissile()
    {
        Missile missile = GameObject.Instantiate(missilePf, transform.position, Quaternion.identity);
        missile.Setup(skill.Unit, skill.Target, skill.Damage);
    }
}
