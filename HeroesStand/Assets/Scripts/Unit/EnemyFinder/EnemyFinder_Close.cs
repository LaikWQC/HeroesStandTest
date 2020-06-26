using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder_Close : EnemyFinder
{
    public override bool FindEnemy()
    {
        if (enemies.Count == 0)
            target = null;
        else
        {
            float bestDistance = float.MaxValue;
            foreach(Unit enemy in enemies)
            {
                float distance = Vector2.Distance(enemy.Position, unit.Position);
                if(distance<bestDistance)
                {
                    bestDistance = distance;
                    target = enemy;
                }
            }
        }
        return base.FindEnemy();
    }
}
