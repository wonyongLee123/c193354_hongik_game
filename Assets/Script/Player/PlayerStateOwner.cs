using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pRewind: State<Player>{
    private pRewind(){}
    private static pRewind instance;
    public static pRewind Instance{
        get{
            if(instance == null) instance = new pRewind();
            return instance;
        }        
    }
    public override void Enter(Player player)
    {
        
    }

    public override void Execute(Player player)
    {
        player.Rewind();
        if (player.IsRewindDone())
        {
            player.FSM.ChangeState(pNormal.Instance);
        }
    }

    public override void Exit(Player player)
    {
        
    }
}

public class pNormal: State<Player>{
    private pNormal(){ }
    private static pNormal instance;
    public static pNormal Instance{
        get{
            if(instance == null) instance = new pNormal();
            return instance;
        }        
    }
    public override void Enter(Player player)
    {
        
    }

    public override void Execute(Player player)
    {
        player.Move();
        player.Shoot();
    }

    public override void Exit(Player player)
    {
        
    }
}

public class pGlobalState: State<Player>{
    private pGlobalState(){}
    private static pGlobalState instance;
    public static pGlobalState Instance{
        get{
            if(instance == null) instance = new pGlobalState();
            return instance;
        }        
    }
    public override void Enter(Player player)
    {
        
    }

    public override void Execute(Player player)
    {
        if (player.FSM.CurrentState == pRewind.Instance) return;
        if (Input.GetKeyDown("z")) // for testing change it event later
        {
            player.FSM.ChangeState(pRewind.Instance);
        }
        player.Record();
    }

    public override void Exit(Player player)
    {
        
    }
}
