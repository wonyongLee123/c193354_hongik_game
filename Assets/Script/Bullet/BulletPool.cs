using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Pbullet _pbulletPrefab = Resources.Load<Pbullet>("PBullet");
    private Ebullet _ebulletPrefab = Resources.Load<Ebullet>("Ebullet");
    private static BulletPool instance;
    private BulletPool(){}
    private List<Pbullet> _playerBulletPool = new List<Pbullet>();
    private Queue<int> _playerDeadPoolIndex = new Queue<int>();
    private int _playerBulletIndex = 0;
    private List<Ebullet> _enemyBulletPool = new List<Ebullet>();
    private Queue<int> _enemyDeadPoolIndex = new Queue<int>();
    private int _enemyBulletIndex = 0;

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
    
    public void EnemyShoot(Transform transform)
    {
        if (_playerDeadPoolIndex.Count != 0)
        {
            Ebullet reclaimBullet = _enemyBulletPool[_enemyDeadPoolIndex.Dequeue()];
            reclaimBullet.gameObject.SetActive(true);   
            return;
        }        
        _enemyBulletPool.Add(MonoBehaviour.Instantiate(_ebulletPrefab,transform.position,transform.rotation));
    }

    public int GetIndexOfNewEnemyBullet(){
        return _enemyBulletIndex++;
    }
   
    public void DestroyEnemyBullet(int index)
    {
        _enemyBulletPool[index].gameObject.SetActive(false);
        _enemyDeadPoolIndex.Enqueue(index);        
    }
}
