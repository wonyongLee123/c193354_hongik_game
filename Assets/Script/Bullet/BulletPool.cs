using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Pbullet prefab = Resources.Load<Pbullet>("PBullet");
    private static BulletPool instance;
    private BulletPool(){}
    private Queue<Pbullet> livingPool;
    private Queue<Pbullet> deadPool;

    public static BulletPool Instance
    {
        get
        {
            if (instance == null) instance = new BulletPool();
            return instance;
        }
    }

    public void CreateNewBullet(Transform transform)
    {
        if (deadPool.Count != 0)
        {
            
        }
    }
   
    public void DestroyBullet(Pbullet bullet)
    {
        bullet.gameObject.SetActive(false);
        deadPool.Enqueue(livingPool.Dequeue());
    }
    
}
