using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewind: State<Player>{
    private PlayerRewind(){}
    private static PlayerRewind instance;
    public static PlayerRewind Instance{
        get{
            if(instance == null) instance = new PlayerRewind();
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
            player.FSM.ChangeState(PlayerNormal.Instance);
        }
    }

    public override void Exit(Player player)
    {
        
    }
}

public class PlayerNormal: State<Player>{
    private PlayerNormal(){ }
    private static PlayerNormal instance;
    public static PlayerNormal Instance{
        get{
            if(instance == null) instance = new PlayerNormal();
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
        player.Record();
    }

    public override void Exit(Player player)
    {
        
    }
}
