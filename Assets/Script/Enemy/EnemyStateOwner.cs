using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExecutePattern : State<Enemy>
{
    private EnemyExecutePattern()
    { }

    private static EnemyExecutePattern instance;
    
    public static EnemyExecutePattern Instance
    {
        get{
            if(instance == null) instance = new EnemyExecutePattern();
            return instance;
        }  
    }

    public override void Enter(Enemy enemy)
    {
        enemy.InitCurrentPattern();
    }

    public override void Execute(Enemy enemy)
    {
        enemy.ExecuteCurrentPattern();
        
        if (enemy.GetCurrentPattern().IsPatternOver())
        {
            enemy.FSM.ChangeState(instance);    
        }
    }

    public override void Exit(Enemy enemy)
    {
        enemy.ExitCurrentPattern();
    }
}

