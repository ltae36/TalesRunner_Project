using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절
    public float rotationSpeed = 10f; // 회전 속도 조절
    public float reverseSpeedMultiplier = 0.5f; // 후진 속도 비율 조절





    void Update()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 로컬 공간에서의 이동 방향을 계산합니다
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // 이동 방향 벡터의 길이가 일정 값보다 크면 회전 및 이동합니다
        if (movement.magnitude > 0.1f)
        {
            // 로컬 이동 방향을 월드 공간으로 변환합니다
            Vector3 localMoveDirection = transform.TransformDirection(movement);

            // 이동 방향으로 회전을 계산합니다
            Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection);

            // 부드럽게 회전하기 위해 Lerp를 사용합니다
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // 이동 방향을 기반으로 캐릭터를 이동시킵니다
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // S 키를 누르면 캐릭터가 바로 뒤를 바라보도록 설정합니다
            transform.forward = -transform.forward;



        }
    }

}


