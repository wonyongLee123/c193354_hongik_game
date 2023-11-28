using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCircleShot : BulletPatternBase
{
    private int _angle = 0;
    public override void Init()
    {
        SetPatternDuration(Random.Range(5,10));
        SetPatternCoolDown(5);
    }
    public override void Execute()
    {
        BulletPool.Instance.EnemyShoot(Vector2.zero,Quaternion.Euler(0, 0, _angle));
        _angle -= Random.Range(10, 20);
    }

    public override void End()
    {
        
    }
}
