using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float rotationSpeed = 10f; // ȸ�� �ӵ� ����
    public float reverseSpeedMultiplier = 0.5f; // ���� �ӵ� ���� ����





    void Update()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ���� ���������� �̵� ������ ����մϴ�
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // �̵� ���� ������ ���̰� ���� ������ ũ�� ȸ�� �� �̵��մϴ�
        if (movement.magnitude > 0.1f)
        {
            // ���� �̵� ������ ���� �������� ��ȯ�մϴ�
            Vector3 localMoveDirection = transform.TransformDirection(movement);

            // �̵� �������� ȸ���� ����մϴ�
            Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection);

            // �ε巴�� ȸ���ϱ� ���� Lerp�� ����մϴ�
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // �̵� ������ ������� ĳ���͸� �̵���ŵ�ϴ�
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // S Ű�� ������ ĳ���Ͱ� �ٷ� �ڸ� �ٶ󺸵��� �����մϴ�
            transform.forward = -transform.forward;



        }
    }

}


