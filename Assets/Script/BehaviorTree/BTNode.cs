using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Abstract class of BT Node
 *  contains BT Status and BTNode
 */

public enum BTNodeStatus
{
 Running = 0,
 Success,
 Fail
}

public abstract class BTNode
{
    public abstract BTNodeStatus Execute();
}