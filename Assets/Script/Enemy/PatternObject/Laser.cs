using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation animation;
    private BoxCollider2D collider2D;
    private Player player;
    private void Start()
    {
        animation = GetComponent<Animation>();
        collider2D = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<Player>();
        animation["Laser"].clip.AddEvent(new AnimationEvent { time = animation["Laser"].clip.length, functionName = "OnAnimationEnd" });
        float randomRotation = Random.Range(0f, 1f) * 180f;
        Vector2 targetPos;
        if (player != null)
        {
            targetPos = player.transform.position;
        }
        else
        {
            targetPos = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        }
        
        transform.position = new Vector2(targetPos.x, targetPos.y);
        transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
        collider2D.enabled = false;
    }
    
    public void OnAnimationEnd()
    {
        collider2D.enabled = true;
        GameManager.Instance.Shake();
        Invoke("DeleteObject",1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }
    private void DeleteObject()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        
    }
}
