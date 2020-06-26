using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyFinder_Any : EnemyFinder
{
    public override void FindEnemy()
    {
        unit.Target = enemies.FirstOrDefault();
    }
}
