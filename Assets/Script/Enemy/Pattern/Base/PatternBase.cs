using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PatternBase 
{
    private float _coolDown = 100;
    private float _currentCoolDown = 0;
    protected void SetPatternCoolDown(float time){ _coolDown = time; }
    protected bool IsExecutable() { return _currentCoolDown < 0; }
    public abstract void Init();
    public abstract void Execute();
    public abstract void End();
}
