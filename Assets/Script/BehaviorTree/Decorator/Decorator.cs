using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorator : BTNode
{
    protected BTNode child;
    public void SetChild(BTNode child)
    {
        this.child = child;
    }

    public override BTNodeStatus Execute()
    {
        return BTNodeStatus.Running;
    }
}
