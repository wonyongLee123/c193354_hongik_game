using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Pbullet prefab = Resources.Load<Pbullet>("PBullet");
    private static BulletPool instance;
    private BulletPool(){}
    private List<Pbullet> pool = new List<Pbullet>();
    private Queue<int> deadPoolIndex = new Queue<int>();
    private int bulletIndex = 0;

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
        if (deadPoolIndex.Count != 0)
        {
            Pbullet reclaimBullet = pool[deadPoolIndex.Dequeue()];
            reclaimBullet.gameObject.SetActive(true);   
            reclaimBullet.Reclaim(transform);
            return;
        }        
        pool.Add(MonoBehaviour.Instantiate(prefab,transform.position,transform.rotation));
    }

    public int GetIndexOfNewBullet(){
        return bulletIndex++;
    }
   
    public void DestroyBullet(int index)
    {
        pool[index].gameObject.SetActive(false);
        deadPoolIndex.Enqueue(index);        
    }
    
}
