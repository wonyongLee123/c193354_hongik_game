using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatUntilFail : Decorator
{
    /*
     *  Repeat Until Fail
     */
    
    public override BTNodeStatus Execute()
    {
        BTNodeStatus stat = child.Execute();

        switch (stat)
        {
            case BTNodeStatus.Running:
                return BTNodeStatus.Running;
            
            case BTNodeStatus.Success:
                return BTNodeStatus.Running;
            
            case BTNodeStatus.Fail: 
                return BTNodeStatus.Fail;
            
            default:
                return BTNodeStatus.Running;
        }
    }
}
