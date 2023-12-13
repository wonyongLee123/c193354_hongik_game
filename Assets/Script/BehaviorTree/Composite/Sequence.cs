using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/*
 *
 *  Sequence Node (AND)
 *  if any of child return Fail, it automatically stop and return Fail
 */

public class Sequence : Composite
{
    public override BTNodeStatus Execute()
    {
        BTNodeStatus stat = child[sequence].Execute();

        switch (stat)
        {
            case BTNodeStatus.Running:
                return BTNodeStatus.Running;
            
            case BTNodeStatus.Success:
                sequence += 1;
                if (child.Count > sequence)
                {
                    return BTNodeStatus.Running;
                }
                sequence = 0;
                return BTNodeStatus.Success;
            
            case BTNodeStatus.Fail:
                return BTNodeStatus.Fail;
            
            default:
                return BTNodeStatus.Running;
        }
    }
}
