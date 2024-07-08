using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Back_Camera : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (캐릭터)

    public Vector3 offset = new Vector3(0f, 3f, -10f); // 카메라와 캐릭터 사이의 거리 및 위치 조정

    public float smoothSpeed = 0.125f; // 카메라 이동을 부드럽게 하기 위한 속도

    void LateUpdate()
    {
        if (target == null) return; // 대상이 없으면 함수 종료

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;




        transform.LookAt(target.position); // 카메라가 캐릭터를 바라보도록 함
    }
}
