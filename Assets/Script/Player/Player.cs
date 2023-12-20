using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ObserverInterface
{
    public float rotationSpeed = 100.0f;

    public float radius = 3.0f; // radius of player move circle  =  distance between player and enemey

    public float minimumRange = 2.0f;
    public float maximumRange = 10.0f;
    public int maxRecordFrame = 300; // 60fps -> 5seconds
    private Deque recorder;
    private FSM<Player> playerFSM;
    private float angle = 270.0f; // current angle
    public Pbullet bullet;
    

    private void Start()
    {
        Application.targetFrameRate = 60; // for testing
        recorder = new Deque();
        playerFSM = new FSM<Player>(this);
        playerFSM.ChangeState(PlayerNormal.Instance); //setting init state
        MessageManager.Instance.RegisterObserver(this);
    }

    private void Update(){        
        playerFSM.Update();
    }

    private void SetPlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
        float targetAngle = Mathf.Atan2(newPosition.y,newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, targetAngle+90);
    }


    public void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float nextRad = radius - verticalInput / 10f;

        if(nextRad >= minimumRange && nextRad <= maximumRange)
        {
            radius = nextRad;
        }else if(nextRad < minimumRange)
        {
            radius = minimumRange;
        }else if(nextRad > maximumRange)
        {
            radius = maximumRange;
        }                

        angle += horizontalInput * rotationSpeed * Time.deltaTime;

        float radians = angle * Mathf.Deg2Rad;
        Vector2 newPosition = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;        

        SetPlayerPosition(newPosition);
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false) return;
        BulletPool.Instance.PlayerShoot(transform);
    }

    public void Record()
    {
        if(recorder.Count > maxRecordFrame)
        {
            recorder.RemoveBack();
            recorder.AddFront(transform.position);      
        }
        else
        {
            recorder.AddFront(transform.position);
        }
    }

    public void Rewind()
    {      
        Vector2 newPosition = recorder.RemoveFront();

        SetPlayerPosition(newPosition);
        if (IsRewindDone())
        {
            float radians = Mathf.Atan2(newPosition.y, newPosition.x);
            angle = radians * Mathf.Rad2Deg;
            radius = Vector3.Distance(newPosition, Vector2.zero);
        }
    }
    
    public bool IsRewindDone()
    {
        return recorder.Count == 0;
    }

    public void HandleMessages(Object sender ,Messages msg)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    public FSM<Player> FSM{
        get{
            return playerFSM;
        }
    }
}
