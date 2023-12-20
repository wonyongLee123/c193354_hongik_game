using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : ActionPatternBase
{
    private int frequency = 0;
    private Laser laser = Resources.Load<Laser>("Laser");
    public override void Init()
    {
        SetPatternDuration(10);
        SetPatternCoolDown(40);
    }
    public override void Execute()
    {
        frequency++;
        if (frequency % 30 == 0)
        {
            Object.Instantiate(laser);
        }
    }

    public override void End()
    {
        
    }
}
