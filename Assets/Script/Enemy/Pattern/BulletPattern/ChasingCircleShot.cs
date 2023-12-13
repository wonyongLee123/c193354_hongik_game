using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingCircleShot : BulletPatternBase
{
    private int angle = 0;
    
    public override void Init()
    {
        SetPatternDuration(Random.Range(5,10));
        SetPatternCoolDown(10);
    }
    public override void Execute()
    {
        BulletPool.Instance.EnemyChaseShoot(Vector2.zero,Quaternion.Euler(0, 0, angle));
        angle += Random.Range(10, 20);
    }

    public override void End()
    {
        
    }
}
