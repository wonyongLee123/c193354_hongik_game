using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State
    {
        normal = 0,
        cannotMove,
        cannotAttack,
        rewind
    }

    public float rotationSpeed = 100.0f; // 회전 속도

    public float radius = 5.0f; // 원의 반지름

    public float minimumRange = 2.0f;
    public float maximumRange = 10.0f;
    public int maxRecordFrame = 300;
    public Deque recorder;
    public GameObject Enemy;


    private float angle = 0.0f; // 현재 각도
    private State currentState;

    private void Start()
    {
        currentState = State.normal;
        recorder = new Deque();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.normal:
                Move();
                Shooting();
                Recording();
                break;

            case State.cannotMove:
                Shooting();
                break;

            case State.cannotAttack:
                Move();
                break;

            case State.rewind:
                Rewinding();
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

        if (Input.GetKeyDown("z"))
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
            radius = 2.0f;
        }else if(nextRad > maximumRange)
        {
            radius = 10.0f;
        }                

        angle += horizontalInput * rotationSpeed * Time.deltaTime;

        float radians = angle * Mathf.Deg2Rad;
        Vector2 newPosition = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;        

        transform.position = newPosition;
        float targetAngle = Mathf.Atan2(0 - newPosition.y, 0 - newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }

    private void Shooting()
    {

    }

    private void Recording()
    {
        if(recorder.Count > maxRecordFrame)
        {
            Vector2 remove = recorder.RemoveBack();
            recorder.AddFront(transform.position);
            //Debug.Log("pos: " + transform.position + " removed: " + remove );
        }
        else
        {
            recorder.AddFront(transform.position);
            //Debug.Log("pos: " + transform.position);
        }
    }

    private void Rewinding()
    {
        Debug.Log("rewinding");
        if(recorder.Count == 0)
        {
            Vector2 currentPos = transform.position;
            float radians = Mathf.Atan2(currentPos.y, currentPos.x);
            angle = radians * Mathf.Rad2Deg;
            radius = Vector3.Distance(transform.position, Enemy.transform.position);            
            ChangeState(State.normal);
            return;
        }
        Vector2 newPosition = recorder.RemoveFront();
        transform.position = newPosition;
        float targetAngle = Mathf.Atan2(0 - newPosition.y, 0 - newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }
}
