using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public override BTNodeStatus Execute( )
    {
        BTNodeStatus stat = child[sequence].Execute();

        switch (stat)
        {
            case BTNodeStatus.Running:
                return BTNodeStatus.Running;
            
            case BTNodeStatus.Success:
                return BTNodeStatus.Success;
            
            case BTNodeStatus.Fail:
                sequence += 1;
                if (child.Count > sequence)
                {
                    return BTNodeStatus.Running;
                }

                sequence = 0;
                return BTNodeStatus.Fail;
            
            default:
                return BTNodeStatus.Running;
        }
    }
}
