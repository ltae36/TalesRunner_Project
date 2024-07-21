using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 10f; // 이동 속도
    public float rotationSpeed = 100f; // 회전 속도




    void Update()

    {
        // 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 처리
        MoveCharacter(horizontalInput, verticalInput);

        // 회전 처리
        RotateCharacter(horizontalInput, verticalInput);
    }

    void MoveCharacter(float horizontalInput, float verticalInput)
    {
        // 이동 방향 설정
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // 실제 이동 처리
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void RotateCharacter(float horizontalInput, float verticalInput)
    {
        // 회전 방향 설정
        Vector3 rotateDirection = new Vector3(horizontalInput, 0, verticalInput);

        // 회전 각도 계산
        if (rotateDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotateDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}


