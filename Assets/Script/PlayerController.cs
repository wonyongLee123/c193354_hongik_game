using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // 회전 속도
    public float radius = 5.0f; // 원의 반지름

    private float angle = 0.0f; // 현재 각도

    private void Update()
    {
        Move();
        
    }

    void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");    

        if(radius>=2.0f && radius<=10.0f){
            radius -= verticalInput/100f;
        }else if(radius<=2.0f){
            radius = 2.0f;
        }else if(radius>=10.0f){
            radius = 10.0f;
        }
        Debug.Log(horizontalInput);
        

        angle += horizontalInput * rotationSpeed * Time.deltaTime;

        float radians = angle * Mathf.Deg2Rad;
        Vector2 newPosition = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
        

        transform.position = newPosition;
        float targetAngle = Mathf.Atan2(0 - newPosition.y, 0 - newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }
}
