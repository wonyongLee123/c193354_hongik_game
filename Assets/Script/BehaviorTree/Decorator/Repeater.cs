using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : Decorator
{
    /*
     *  Repeater Repeat Until Success 
     */
    
    public override BTNodeStatus Execute()
    {
        BTNodeStatus stat = child.Execute();

        switch (stat)
        {
            case BTNodeStatus.Running:
                return BTNodeStatus.Running;
            
            case BTNodeStatus.Success: 
                return BTNodeStatus.Fail;
            
            case BTNodeStatus.Fail: 
                return BTNodeStatus.Running;
            
            default:
                return BTNodeStatus.Running;
        }
    }
}
