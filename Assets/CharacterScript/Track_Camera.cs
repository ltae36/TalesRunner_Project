using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Camera : MonoBehaviour
{
    public Transform target; // 따라갈 타겟 (캐릭터)
    public Vector3 offset;   // 카메라와 타겟 간의 오프셋
    public float smoothSpeed = 0.125f; // 부드러운 이동 속도
    void Update()

    {

    }

    void LateUpdate()
    {
        // 타겟의 위치에 오프셋을 더한 위치 계산
        Vector3 desiredPosition = target.position + offset;
        // 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // 카메라가 타겟의 방향을 바라보도록 회전
        transform.LookAt(target);
    }
}