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
    private bool onRewinding;
    
    
    public float bulletSpeed = 5.0f;
    public int maxRecordFrame = 300;

    void Start()
    {
        recorder = new Deque();
        recorder.AddFront(Vector2.zero);
        rb2 = GetComponent<Rigidbody2D>();
        currentState = State.move;
        rewindableCount = 0;
        onRewinding = false;
        cd = GetComponent<CircleCollider2D>();
        move();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z")) // for testing
        {
            ChangeState(State.rewind);
            return;
        }
        switch(currentState){
            case State.move:
            Record();
            break;

            case State.collided:
            Record();
            Collided();
            break;

            case State.rewind:
            Rewind();
            break;
        }
    }
    public void ChangeState(State state){
        currentState = state;
    }
    private void move(){
        moveDirection = (Vector3.zero - transform.position).normalized;
        rb2.velocity = moveDirection * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            rb2.velocity = Vector3.zero;            
            transform.position = new Vector2(5000,5000);
            cd.isTrigger = false;
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
        rewindableCount++;
        if(rewindableCount == maxRecordFrame) Destroy(gameObject);
    }

    private void Rewind()
    {   
        
        if(!onRewinding)
        {
            rb2.velocity = Vector3.zero;
            onRewinding = true;
        }
        

        Vector2 newPosition = recorder.RemoveFront();
        transform.position = newPosition;

        if (recorder.Count == 0)
        {
            Debug.Log("endReWind");
            if (transform.position.x == 0 && // Condition: bullet does not shooted in rewinded time
                transform.position.y == 0){
                    Destroy(gameObject);
                }
            
            move();
            onRewinding = false;
            cd.isTrigger = true;
            this.ChangeState(State.move);
        }
    }
}
