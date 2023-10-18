using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Pbullet prefab;
    private static BulletPool instance;
    private BulletPool(){}

    public static BulletPool Instance
    {
        get
        {
            if (instance == null) instance = new BulletPool();
            return instance;
        }
    }
    public Queue<Pbullet> pool;

    public void addObjectToPool(Pbullet bullet)
    {
        pool.Enqueue(bullet);
    }
    
}
