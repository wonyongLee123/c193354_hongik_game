using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class Enemy : EnemyBase, ObserverInterface
{
    private FSM<Enemy> enemyFSM;
    
    private void Awake()
    {
        this.SetEnemyInitHp(100);
        this.SetEnemyPatterns();
        this.SelectPattern();
    }

    private void Start()
    {
        MessageManager.Instance.RegisterObserver(this);
        enemyFSM = new FSM<Enemy>(this);
        enemyFSM.ChangeState(EnemyExecutePattern.Instance);
    }

    private void Update()
    {
        enemyFSM.Update();
    }

    public void HandleMessages(Object sender, Messages msg)
    {
        if (sender is Pbullet) // message from player bullet
        {
            if (msg is DamageMessage) // message type is damage
            {
                DamageMessage damageMessage = (DamageMessage)msg;
                this.Damaged(damageMessage.Damage);
            }
        }
    }

    public void InitCurrentPattern()
    {
        GetCurrentPattern().Init();
    }

    public void ExecuteCurrentPattern()
    {
        GetCurrentPattern().Execute();
        GetCurrentPattern().OnPattern();
    }

    public void ExitCurrentPattern()
    {
        GetCurrentPattern().End();
        StartCoroutine(GetCurrentPattern().Cooldown());
        SelectPattern();
    }
    
    public FSM<Enemy> FSM{
        get{
            return enemyFSM;
        }
    }
}
