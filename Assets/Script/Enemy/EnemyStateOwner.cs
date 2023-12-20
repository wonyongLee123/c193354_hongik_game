

public class EnemyExecutePattern : State<Enemy>
{
    private EnemyExecutePattern()
    { }

    private static EnemyExecutePattern _instance;
    
    public static EnemyExecutePattern Instance
    {
        get{
            if(_instance == null) _instance = new EnemyExecutePattern();
            return _instance;
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
            enemy.FSM.ChangeState(_instance);    
        }
    }

    public override void Exit(Enemy enemy)
    {
        enemy.ExitCurrentPattern();
    }
}

