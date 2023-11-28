using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composite : BTNode
{
    protected List<BTNode> child = new List<BTNode>();
    protected int sequence = 0;
    public void AddChild(BTNode child)
    {
        this.child.Add(child);
    }

    public override BTNodeStatus Execute()
    {
        return BTNodeStatus.Running;
    }
}
