using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPillarState : BTNode
{
    private BossPillar[] pillars;
    private float patternCount = 60;
    private float timer = 0;
    private int pillarCount;
    public override BTNodeStatus Execute()
    {
        pillarCount = 0;
        if (timer == 0)
        {
            pillars = GameObject.FindObjectsOfType<BossPillar>();
        }
        
        timer += Time.deltaTime;

        for (int i = 0; i < pillars.Length; ++i)
        {
            if (pillars[i].isActiveAndEnabled)
            {
                pillarCount++;
            }
        }
        if (pillarCount == 0)
        {
            timer = 0;
            return BTNodeStatus.Success;
        }
        
        if (timer > patternCount)
        {
            timer = 0;
            return BTNodeStatus.Fail;
        }

        return BTNodeStatus.Running;
    }
}
