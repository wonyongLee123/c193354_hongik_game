using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private float _hp;
    private List<PatternBase> _patterns = new List<PatternBase>();
    private int _currentPatternIndex;
    private void Start()
    {
    }
    private void Update()
    {
       
    }

    protected void SetEnemyInitHp(float hp)
    {
        _hp = hp;
    }

    protected void SetEnemyPatterns()
    {
        _patterns.Add(new CircleShot());
        _patterns.Add(new BackCircleShot());
        _patterns.Add(new ChasingCircleShot());
    }

    protected void SelectPattern()
    {
        while (_patterns[_currentPatternIndex].IsCoolDown())
        {
            _currentPatternIndex = Random.Range(0, _patterns.Count);
        }
    }

    protected void Damaged(float damage)
    {
        _hp -= damage;
    }

    protected float GetHp()
    {
        return _hp;
    }

    public PatternBase GetCurrentPattern()
    {
        return _patterns[_currentPatternIndex];
    }
}
