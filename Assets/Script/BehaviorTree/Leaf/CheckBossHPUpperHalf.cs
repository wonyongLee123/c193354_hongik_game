using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBossHpUpperHalf : BTNode
{
    private Enemy enemy = GameObject.FindObjectOfType<Enemy>();
    public override BTNodeStatus Execute()
    {
        if (enemy.GetHpPercentage() > 50.0f) return BTNodeStatus.Success;

        return BTNodeStatus.Fail;
    }
}
