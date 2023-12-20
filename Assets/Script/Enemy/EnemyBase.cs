using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private float hp;
    private float currentHp;
    private List<PatternBase> patterns = new List<PatternBase>();
    private int currentPatternIndex;
    private void Start()
    {
    }
    private void Update()
    {
       
    }

    protected void SetEnemyInitHp(float hp)
    {
        this.hp = hp;
        currentHp = this.hp;
    }

    protected void SetEnemyPatterns()
    {
        patterns.Add(new CircleShot());
        patterns.Add(new BackCircleShot());
        patterns.Add(new ChasingCircleShot());
        patterns.Add(new FallObject());
        patterns.Add(new SwingSword());
        patterns.Add(new GimmikPillar());
        patterns.Add(new LaserAttack());
    }

    protected void SelectPattern()
    {
        while (patterns[currentPatternIndex].IsCoolDown())
        {
            currentPatternIndex = Random.Range(0, patterns.Count);
        }
    }

    protected void Damaged(float damage)
    {
        currentHp -= damage;
    }

    public float GetHp()
    {
        return currentHp;
    }

    public float GetHpPercentage()
    {
        return (currentHp / hp) * 100;
    }

    protected bool IsDead()
    {
        return hp <= 0;
    }

    public PatternBase GetCurrentPattern()
    {
        return patterns[currentPatternIndex];
    }
}
