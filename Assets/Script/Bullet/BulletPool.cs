using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Pbullet pBulletPrefab = Resources.Load<Pbullet>("PBullet");
    private Ebullet enemyBulletPrefab = Resources.Load<Ebullet>("EBullet");
    private EbulletChase eBulletChasePrefab = Resources.Load<EbulletChase>("EBulletChase");
    private FallingObject fallingObject = Resources.Load<FallingObject>("FallingObject");
    
    private static BulletPool _instance;
    private BulletPool(){}
    
    private List<Pbullet> playerBulletPool = new List<Pbullet>();
    private Queue<int> playerDeadPoolIndex = new Queue<int>();
    private int playerBulletIndex = 0;
    
    private List<Ebullet> enemyBulletPool = new List<Ebullet>();
    private Queue<int> enemyDeadPoolIndex = new Queue<int>();
    private int enemyBulletIndex = 0;

    private List<EbulletChase> enemyChaseBulletPool = new List<EbulletChase>();
    private Queue<int> enemyChaseDeadPoolIndex = new Queue<int>();
    private int enemyChaseBulletIndex = 0;

    private List<FallingObject> fallingObjectPool = new List<FallingObject>();
    private Queue<int> fallingObjectPoolIndex = new Queue<int>();
    private int fallingObjectIndex = 0;
    
    public static BulletPool Instance
    {
        get
        {
            if (_instance == null) _instance = new BulletPool();
            return _instance;
        }
    }

    public void PlayerShoot(Transform transform)
    {
        if (playerDeadPoolIndex.Count != 0)
        {
            Pbullet reclaimBullet = playerBulletPool[playerDeadPoolIndex.Dequeue()];
            reclaimBullet.gameObject.SetActive(true);   
            reclaimBullet.Reclaim(transform);
            return;
        }        
        playerBulletPool.Add(Object.Instantiate(pBulletPrefab,transform.position,transform.rotation));
    }

    public int GetIndexOfNewPlayerBullet(){
        return playerBulletIndex++;
    }
   
    public void DestroyPlayerBullet(int index)
    {
        playerBulletPool[index].gameObject.SetActive(false);
        playerDeadPoolIndex.Enqueue(index);        
    }
    
    public void EnemyShoot(Vector2 position, Quaternion rotation)
    {
        if (enemyDeadPoolIndex.Count != 0)
        {
            Ebullet reclaimBullet = enemyBulletPool[enemyDeadPoolIndex.Dequeue()];
            reclaimBullet.transform.position = position;
            reclaimBullet.transform.rotation = rotation;
            reclaimBullet.gameObject.SetActive(true);   
            return;
        }        
        enemyBulletPool.Add(Object.Instantiate(enemyBulletPrefab,position,rotation));
    }
    
    public void EnemyChaseShoot(Vector2 position, Quaternion rotation)
    {
        if (enemyChaseDeadPoolIndex.Count != 0)
        {
            EbulletChase reclaimBullet = enemyChaseBulletPool[enemyChaseDeadPoolIndex.Dequeue()];
            reclaimBullet.transform.position = position;
            reclaimBullet.transform.rotation = rotation;
            reclaimBullet.gameObject.SetActive(true);   
            return;
        }        
        enemyChaseBulletPool.Add(Object.Instantiate(eBulletChasePrefab,position,rotation));
    }

    public int GetIndexOfNewEnemyBullet(){
        return enemyBulletIndex++;
    }

    public int GetIndexOfNewEnemyChaseBullet()
    {
        return enemyChaseBulletIndex++;
    }
   
    public void DestroyEnemyBullet(int index)
    {
        enemyBulletPool[index].gameObject.SetActive(false);
        enemyDeadPoolIndex.Enqueue(index);        
    }
    
    public void DestroyEnemyChaseBullet(int index)
    {
        enemyChaseBulletPool[index].gameObject.SetActive(false);
        enemyChaseDeadPoolIndex.Enqueue(index);        
    }
    
    public void SpawnFallingObject()
    {
        if (fallingObjectPoolIndex.Count != 0)
        {
            FallingObject newObject = fallingObjectPool[fallingObjectPoolIndex.Dequeue()];
            newObject.gameObject.SetActive(true);   
            return;
        }        
        fallingObjectPool.Add(Object.Instantiate(fallingObject));
    }

    public int GetIndexOfNewFallingObject()
    {
        return fallingObjectIndex++;
    }

    public void DestroyFallingObject(int index)
    {
        fallingObjectPool[index].gameObject.SetActive(false);
        fallingObjectPoolIndex.Enqueue(index);   
    }
}
