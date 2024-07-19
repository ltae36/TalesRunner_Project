using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Back_Camera : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (캐릭터)

    public Vector3 offset = new Vector3(0f, 3f, -10f); // 카메라와 캐릭터 사이의 거리 및 위치 조정


    void LateUpdate()
    {
        if (target == null) return; // 대상이 없으면 함수 종료

        
        transform.position = target.position + offset; // 타겟 위치에 offset을 더하여 카메라의 위치 설정

        
        transform.LookAt(target.position); // 타겟을 바라보도록 카메라 회전



    }
}
