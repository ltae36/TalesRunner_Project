using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 10f; // �̵� �ӵ�
    public float rotationSpeed = 100f; // ȸ�� �ӵ�




    void Update()

    {
        // �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �̵� ó��
        MoveCharacter(horizontalInput, verticalInput);

        // ȸ�� ó��
        RotateCharacter(horizontalInput, verticalInput);
    }

    void MoveCharacter(float horizontalInput, float verticalInput)
    {
        // �̵� ���� ����
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // ���� �̵� ó��
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void RotateCharacter(float horizontalInput, float verticalInput)
    {
        // ȸ�� ���� ����
        Vector3 rotateDirection = new Vector3(horizontalInput, 0, verticalInput);

        // ȸ�� ���� ���
        if (rotateDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotateDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}


