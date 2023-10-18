using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // 플레이어의 트랜스폼
    public float zoomSpeed = 2.0f; // 조절 속도
    public float minZoom = 300.0f; // 최소 시야 각도
    public float maxZoom = 500.0f; // 최대 시야 각도
    public float maxZoomDistance = 10.0f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 플레이어와 (0,0) 포지션 사이의 거리 계산
        float distanceToPlayer = Vector3.Distance(player.position, Vector3.zero);

        // 거리에 따라 시야 각도를 조절
        float targetFieldOfView = Mathf.Lerp(minZoom, maxZoom, distanceToPlayer / maxZoomDistance);

        // 시야 각도를 조절할 때 스무딩 적용
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFieldOfView, Time.deltaTime * zoomSpeed);
    }
}
