using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tdffffffffffffffffff : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float turnSpeed = 5;



    public float maxTurnAngle = 45f; // 최대 회전 각도

    public Vector3 movedir;

    public float x;

    public float v;


    void Start()
    {

    }

    void Update()
    {

        // 입력 처리
        float moveInput = Input.GetAxis("Vertical"); // W/S 또는 상하 방향키 입력
        float turnInput = Input.GetAxis("Horizontal"); // A/D 또는 좌우 방향키 입력

        // 이동 방향 계산
        Vector3 moveDirection = transform.forward * moveInput;

        // 차량 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 차량 회전 처리
        if (turnInput != 0)
        {
            // 회전할 방향 벡터 계산
            Vector3 turnDirection = new Vector3(0, turnInput, 0);
            Quaternion turnRotation = Quaternion.Euler(turnDirection * turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * turnRotation, turnSpeed * Time.deltaTime);
        }
    }
}

    


