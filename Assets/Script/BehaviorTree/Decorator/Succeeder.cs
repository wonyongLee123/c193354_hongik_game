using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succeeder : Decorator
{
    /*
     *  Always success 
     */
    
    public override BTNodeStatus Execute()
    {
        BTNodeStatus stat = child.Execute();

        switch (stat)
        {
            case BTNodeStatus.Running:
                return BTNodeStatus.Running;
            
            case BTNodeStatus.Success: 
                return BTNodeStatus.Success;
            
            case BTNodeStatus.Fail:
                return BTNodeStatus.Success;
            
            default:
                return BTNodeStatus.Running;
        }
    }
}
