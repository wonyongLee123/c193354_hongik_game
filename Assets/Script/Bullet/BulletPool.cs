using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Pbullet _pbulletPrefab = Resources.Load<Pbullet>("PBullet");
    private Ebullet _ebulletPrefab = Resources.Load<Ebullet>("EBullet");
    private EbulletChase _ebulletChasePrefab = Resources.Load<EbulletChase>("EBulletChase");
    
    private static BulletPool instance;
    private BulletPool(){}
    
    private List<Pbullet> _playerBulletPool = new List<Pbullet>();
    private Queue<int> _playerDeadPoolIndex = new Queue<int>();
    private int _playerBulletIndex = 0;
    
    private List<Ebullet> _enemyBulletPool = new List<Ebullet>();
    private Queue<int> _enemyDeadPoolIndex = new Queue<int>();
    private int _enemyBulletIndex = 0;

    private List<EbulletChase> _enemyChaseBulletPool = new List<EbulletChase>();
    private Queue<int> _enemyChaseDeadPoolIndex = new Queue<int>();
    private int _enemyChaseBulletIndex = 0;
    
    public static BulletPool Instance
    {
        get
        {
            if (instance == null) instance = new BulletPool();
            return instance;
        }
    }

    public void PlayerShoot(Transform transform)
    {
        if (_playerDeadPoolIndex.Count != 0)
        {
            Pbullet reclaimBullet = _playerBulletPool[_playerDeadPoolIndex.Dequeue()];
            reclaimBullet.gameObject.SetActive(true);   
            reclaimBullet.Reclaim(transform);
            return;
        }        
        _playerBulletPool.Add(MonoBehaviour.Instantiate(_pbulletPrefab,transform.position,transform.rotation));
    }

    public int GetIndexOfNewPlayerBullet(){
        return _playerBulletIndex++;
    }
   
    public void DestroyPlayerBullet(int index)
    {
        _playerBulletPool[index].gameObject.SetActive(false);
        _playerDeadPoolIndex.Enqueue(index);        
    }
    
    public void EnemyShoot(Vector2 position, Quaternion rotation)
    {
        if (_enemyDeadPoolIndex.Count != 0)
        {
            Ebullet reclaimBullet = _enemyBulletPool[_enemyDeadPoolIndex.Dequeue()];
            reclaimBullet.transform.position = position;
            reclaimBullet.transform.rotation = rotation;
            reclaimBullet.gameObject.SetActive(true);   
            return;
        }        
        _enemyBulletPool.Add(MonoBehaviour.Instantiate(_ebulletPrefab,position,rotation));
    }
    
    public void EnemyChaseShoot(Vector2 position, Quaternion rotation)
    {
        if (_enemyChaseDeadPoolIndex.Count != 0)
        {
            EbulletChase reclaimBullet = _enemyChaseBulletPool[_enemyChaseDeadPoolIndex.Dequeue()];
            reclaimBullet.transform.position = position;
            reclaimBullet.transform.rotation = rotation;
            reclaimBullet.gameObject.SetActive(true);   
            return;
        }        
        _enemyChaseBulletPool.Add(MonoBehaviour.Instantiate(_ebulletChasePrefab,position,rotation));
    }

    public int GetIndexOfNewEnemyBullet(){
        return _enemyBulletIndex++;
    }

    public int GetIndexOfNewEnemyChaseBullet()
    {
        return _enemyChaseBulletIndex++;
    }
   
    public void DestroyEnemyBullet(int index)
    {
        _enemyBulletPool[index].gameObject.SetActive(false);
        _enemyDeadPoolIndex.Enqueue(index);        
    }
    
    public void DestroyEnemyChaseBullet(int index)
    {
        _enemyChaseBulletPool[index].gameObject.SetActive(false);
        _enemyChaseDeadPoolIndex.Enqueue(index);        
    }
}
