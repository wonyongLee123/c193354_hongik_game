using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PatternBase 
{
    private float _coolDown = 3;
    private bool _isCoolDown = false;
    private float _patternDuration = 0;
    
    protected void SetPatternCoolDown(float time){ _coolDown = time; }

    public bool IsCoolDown() { return _isCoolDown; }
    protected void SetPatternDuration(float time) { _patternDuration = time; }
    public bool IsPatternOver(){ return _patternDuration <= 0; }
    public abstract void Init();
    public abstract void Execute();
    public abstract void End();

    public void OnPattern()
    {
        _patternDuration -= Time.deltaTime;
    }
    public IEnumerator Cooldown()
    {
        _isCoolDown = true;
        yield return new WaitForSeconds(_coolDown);
        _isCoolDown = false;
    }
}
