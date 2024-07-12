using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Camera : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (캐릭터)
    public float distance = 5f; // 카메라와 캐릭터 사이의 거리
    public float height = 2f; // 카메라의 높이

    void Update()
    {
        if (target != null)
        {
            // 캐릭터의 위치에 대해 뒤로 이동하고 위로 올린 위치 계산
            Vector3 offset = -target.forward * distance + Vector3.up * height;
            // 카메라의 위치를 계산된 위치로 설정
            transform.position = target.position + offset;

            // 캐릭터가 바라보는 방향으로 카메라 회전
            transform.rotation = Quaternion.LookRotation(target.forward, Vector3.up);
        }
    }
}