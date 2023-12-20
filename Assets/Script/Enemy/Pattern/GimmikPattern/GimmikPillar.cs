using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmikPillar : GimmikPatternBase
{
    public GimmikPillar()
    {
        root = new Sequence();
        Selector selector = new Selector();
        Sequence sequence = new Sequence();
        sequence.AddChild(new CheckBossHpUpperHalf());
        sequence.AddChild(new SpawnPillar3());
        selector.AddChild(sequence);
        selector.AddChild(new SpawnPillar5());
        root.AddChild(selector);
        root.AddChild(new CheckPillarState());
        SetPatternCoolDown(60);
    }
    public override void Init()
    {
        SetPatternDuration(60);
        clear = false;
    }
    public override void Execute()
    {
        BTNodeStatus stat = root.Execute();
        if (stat == BTNodeStatus.Success)
        {
            SetPatternDuration(0);
            clear = true;
        }else if (stat == BTNodeStatus.Fail)
        {
            SetPatternDuration(0);
            clear = false;
        }
        
    }

    public override void End()
    {
        if (clear == false)
        {
        }
        else
        {
        }
    }
}
