using UnityEngine;

public class EnemyFinder_Close : EnemyFinder
{
    public override void FindEnemy()
    {
        Unit target = null;
        if (enemies.Count != 0)
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
        unit.Target = target;
    }
}
