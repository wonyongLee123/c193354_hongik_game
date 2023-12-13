using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : BulletPatternBase
{
    private int frequency = 0;
    public override void Init()
    {
        SetPatternDuration(Random.Range(5,10));
        SetPatternCoolDown(20);
    }
    public override void Execute()
    {
        frequency++;
        if (frequency % 10 == 0)
        {
            BulletPool.Instance.SpawnFallingObject();
        }
    }

    public override void End()
    {
        
    }
}
