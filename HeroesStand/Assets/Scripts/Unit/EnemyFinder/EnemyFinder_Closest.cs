using UnityEngine;

public class EnemyFinder_Closest : MonoBehaviour, IEnemyFinder
{
    private IVision vision;
    private Unit unit;

    private void Awake()
    {
        vision = GetComponent<IVision>();
        unit = GetComponentInParent<Unit>();
    }
    public void FindEnemy()
    {
        Unit target = null;
        if (vision.Enemies.Count != 0)
        {
            float bestDistance = float.MaxValue;
            foreach (Unit enemy in vision.Enemies)
            {
                float distance = Vector2.Distance(enemy.Position, unit.Position);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    target = enemy;
                }
            }
        }
        unit.Target = target;
    }
}
