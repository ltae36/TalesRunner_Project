using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Track_Camera : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (캐릭터)
    public float distance = 10f; // 카메라와 캐릭터 사이의 거리
    public float height = 3f; // 카메라의 높이
    

    void LateUpdate()
    {
        if (target == null) return; // 대상이 없으면 함수 종료

        // 타겟 위치와 방향을 기반으로 카메라의 위치 계산
        Vector3 targetPosition = target.position + Vector3.up * height - target.forward * distance;

        // 카메라의 위치 설정
        transform.position = targetPosition;

        // 타겟을 바라보도록 카메라 회전
        transform.LookAt(target.position);
    }
}