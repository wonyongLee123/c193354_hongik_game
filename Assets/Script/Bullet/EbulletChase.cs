using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbulletChase : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private int _index;
    public float speed = 5.0f;
    public float bulletLifetime = 5.0f;
    private void Awake()
    {
        _index = BulletPool.Instance.GetIndexOfNewEnemyChaseBullet(); 
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime), Space.Self);
    }
    
    void OnEnable()
    {
        speed = Random.Range(3.0f, 6.0f);
        StartCoroutine(BulletToTarget());
    }
    
    private IEnumerator BulletToTarget()
    {
        yield return new WaitForSeconds(1.5f);

        Vector3 targetDirection = player.transform.position - transform.position;
         
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        yield return new WaitForSeconds(bulletLifetime);
        
        DisableBullet();
    }        
    
    private void DisableBullet()
    {
        BulletPool.Instance.DestroyEnemyChaseBullet(_index);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisableBullet();
        } else if (collision.CompareTag("BlockPillar"))
        {
            DisableBullet();
        }
    }
}

