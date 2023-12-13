using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSword : ActionPatternBase
{
    private int frequency = 0;
    private Sword sword = Resources.Load<Sword>("Sword");
    public override void Init()
    {
        SetPatternDuration(2);
        SetPatternCoolDown(10);
        Object.Instantiate(sword);
    }
    public override void Execute()
    {
    }

    public override void End()
    {
        
    }
}
