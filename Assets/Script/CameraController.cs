using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float shakeDuration = 0.8f;  // 흔들기 지속 시간
    private float shakeIntensity = 0.3f; // 흔들기 강도

    private Vector3 originalPosition;   // 초기 카메라 위치

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 shakeVector = Random.insideUnitSphere * shakeIntensity;
            transform.position = originalPosition + shakeVector;
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }
}
