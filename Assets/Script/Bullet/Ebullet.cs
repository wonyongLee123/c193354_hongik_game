using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
    private int index;
    public float speed = 5.0f;
    public float bulletLifetime = 5.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        index = BulletPool.Instance.GetIndexOfNewEnemyBullet(); 
    }
    
    void OnEnable()
    {
        speed = Random.Range(3.0f, 6.0f);
        Invoke("DisableBullet",bulletLifetime);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime), Space.Self);
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

    private void DisableBullet()
    {
        BulletPool.Instance.DestroyEnemyBullet(index);
    }
    
}
