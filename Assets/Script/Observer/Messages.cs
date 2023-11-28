using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages
{}
public class DamageMessage: Messages
{
    public DamageMessage(float damage)
    {
        Damage = damage;
    }
    public float Damage { get; set; }
}

