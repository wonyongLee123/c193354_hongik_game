using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 이벤트 핸들러 사용
    public enum State
    {
        normal = 0,
        cannotMove,
        cannotAttack,
        rewind
    }

    public float rotationSpeed = 100.0f;

    public float radius = 3.0f; // radius of player move circle  =  distance between player and enemey

    public float minimumRange = 2.0f;
    public float maximumRange = 10.0f;
    public int maxRecordFrame = 300; // 60fps -> 5seconds
    public Deque recorder;
    public GameObject Enemy;


    private float angle = 270.0f; // current angle
    private State currentState;

    private void Start()
    {
        currentState = State.normal;
        recorder = new Deque();
        Application.targetFrameRate = 60; // for testing
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.normal:
                Move();
                Shoot();
                Record();
                break;

            case State.cannotMove:
                Shoot();
                Record();
                break;

            case State.cannotAttack:
                Move();
                Record();
                break;

            case State.rewind:
                Rewind();
                break;
        }
        
    }

    public void ChangeState(State state)
    {
        currentState = state;
    }

    private void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("z")) // for testing
        {
            ChangeState(State.rewind);
            return;
        }

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

        transform.position = newPosition;
        float targetAngle = Mathf.Atan2( newPosition.y, newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, targetAngle+90);
    }

    private void Shoot()
    {

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

    private void Rewind()
    {      
        Vector2 newPosition = recorder.RemoveFront();

        transform.position = newPosition;
        float targetAngle = Mathf.Atan2(newPosition.y,newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, targetAngle+90);

        if (recorder.Count == 0)
        {
            float radians = Mathf.Atan2(newPosition.y, newPosition.x);
            angle = radians * Mathf.Rad2Deg;
            radius = Vector3.Distance(newPosition, Enemy.transform.position);
            ChangeState(State.normal);
        }
    }
}
