using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // 플레이어(Transform) 오브젝트를 연결할 변수

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // 카메라를 플레이어 위치로 이동
            //transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
