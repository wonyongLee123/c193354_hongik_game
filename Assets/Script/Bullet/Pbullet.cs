using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pbullet : MonoBehaviour
{

    public enum State{
        move = 0,
        collided,
        rewind
    }
    private Deque recorder;
    private Rigidbody2D rb2;
    private State currentState;
    private Vector3 moveDirection;
    private CircleCollider2D cd;
    private int rewindableCount;
    private int index;
    


    public float bulletSpeed = 5.0f;
    public int maxRecordFrame = 300;

    private void Awake()
    {
        recorder = new Deque();
        rb2 = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        currentState = State.move;
        rewindableCount = 0;        
        index = BulletPool.Instance.GetIndexOfNewPlayerBullet();
        Move();
    }

    // Update is called once per frame
    private void Update()
    {
        switch(currentState){
            case State.move:
            Record();
            Testing();
            break;

            case State.collided:
            Record();
            Collided();
            Testing();
            break;

            case State.rewind:
            Rewind();
            break;
        }
    }
    void OnDisable()
    {
        recorder.Empty();
        BulletPool.Instance.DestroyPlayerBullet(index);
    }

    void OnEnable()
    {
        recorder.AddFront(Vector2.zero);
    }

    public void ChangeState(State state){
        currentState = state;
    }
    
    private void Move(){
        moveDirection = (Vector3.zero - transform.position).normalized;
        rb2.velocity = moveDirection * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DisableBullet();            
            transform.position = new Vector2(5000,5000);
            ChangeState(State.collided);
            MessageManager.Instance.SendMessagesToAll(this,new DamageMessage(0.5f));
        }else if (collision.CompareTag("BlockPillar"))
        {
            DisableBullet();
            transform.position = new Vector2(5000,5000);
            ChangeState(State.collided);
        }
        
    }

    private void Record()
    {
        if(recorder.Count > maxRecordFrame)
        {
            Vector2 remove = recorder.RemoveBack();
            recorder.AddFront(transform.position);      
        }
        else
        {
            recorder.AddFront(transform.position);
        }
    }
    private void Collided(){
        rewindableCount += 1;
        if(rewindableCount == maxRecordFrame) gameObject.SetActive(false);
    }

    private void Rewind()
    {   
        transform.position = recorder.RemoveFront();

        if (recorder.Count == 0)
        {
            if (transform.position == Vector3.zero){ // if bullet's last position are 0,0(base)
                gameObject.SetActive(false);
            }
            
            Move();
            cd.isTrigger = true;
            this.ChangeState(State.move);
        }
    }

    private void Testing() // remove it later
    {
        if (Input.GetKeyDown("z")) 
        {
            DisableBullet();
            ChangeState(State.rewind);
        }
    }
    private void DisableBullet()
    {
        rb2.velocity = Vector2.zero;
        cd.isTrigger = false;
    }
    public void InitBullet(Transform newTransform){
        transform.position = newTransform.position;
        transform.rotation = newTransform.rotation;
    }
    public void Reclaim(Transform newTransform){
        InitBullet(newTransform);
        Move();
    }
    
}
