
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossPillar : MonoBehaviour
{
    // Start is called before the first frame update*
    private float hp = 10;
    private GameObject healthBar;
    private GameObject healthBarInstance;
    private GameObject explosion;
    private int angle;
    private float timer = 0f;
    
    private float interval = 3.0f;


    private void Awake()
    {
        healthBar = Resources.Load<GameObject>("HealthBar");
        explosion = Resources.Load<GameObject>("explosion");
        healthBarInstance = Instantiate(healthBar, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        healthBarInstance.transform.parent = gameObject.transform;
        SetHealthBar();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 경과 시간 누적
        timer += Time.deltaTime;
        // 일정 시간 간격마다 실행
        if (timer >= interval)
        {
            
            for (int i = 0; i < 30; ++i)
            {
                BulletPool.Instance.EnemyShoot(transform.position,Quaternion.Euler(0, 0, angle));
                angle += Random.Range(10, 20);
            }
            // 타이머 초기화
            timer = 0f;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PBullet"))
        {
            hp -= 1.0f;
            SetHealthBar();
            if (hp < 0.0f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        Instantiate(explosion,gameObject.transform.position,gameObject.transform.rotation);
        GameManager.Instance.Shake();
    }

    private void SetHealthBar()
    {
        healthBarInstance.transform.localScale = new Vector3(hp / 10, 0.2f, 0.0f);
    }
}
