
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingObject : MonoBehaviour
{
    private float rotationSpeed = 100.0f;
    private Vector2 targetPos;
    private GameObject remover;
    private GameObject removerObject;
    private GameObject explosion;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private float alphaAdjust = 0.5f;
    private int index;
    private bool adjustAlpha = true;
    private void Awake()
    {
        remover = Resources.Load<GameObject>("remover");
        explosion = Resources.Load<GameObject>("explosion");
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        index = BulletPool.Instance.GetIndexOfNewFallingObject();
    }

    void Start()
    {
    }

    private void OnEnable()
    {
        targetPos = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        rb2d.angularVelocity = rotationSpeed;
        gameObject.transform.position = new Vector2(targetPos.x, targetPos.y + 10.0f);
        rb2d.velocity = new Vector2(0, -4);
        removerObject = Instantiate(remover, targetPos, Quaternion.identity);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.0f);
        adjustAlpha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (adjustAlpha)
        {
            float alpha = Mathf.Lerp(0f, 255, Mathf.PingPong(Time.time * alphaAdjust, 1f));

            // 알파값 설정
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);

            // 최대 알파값에 도달하면 업데이트 중지
            if (Mathf.Approximately(alpha, 255))
            {
                adjustAlpha = false;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjectRemover"))
        {
            Destroy(removerObject);
            BulletPool.Instance.DestroyFallingObject(index);
            float angle = 0;
            for (int i = 0; i < 10; ++i)
            {
                BulletPool.Instance.EnemyChaseShoot(transform.position,Quaternion.Euler(0, 0, angle));
                angle += Random.Range(10, 20);
            }
        }
    }
    private void OnDisable()
    {
        Instantiate(explosion,gameObject.transform.position,gameObject.transform.rotation);
    }
}
