using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tdffffffffffffffffff : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float turnSpeed = 5;



    public float maxTurnAngle = 45f; // �ִ� ȸ�� ����

    public Vector3 movedir;

    public float x;

    public float v;


    void Start()
    {

    }

    void Update()
    {

        // �Է� ó��
        float moveInput = Input.GetAxis("Vertical"); // W/S �Ǵ� ���� ����Ű �Է�
        float turnInput = Input.GetAxis("Horizontal"); // A/D �Ǵ� �¿� ����Ű �Է�

        // �̵� ���� ���
        Vector3 moveDirection = transform.forward * moveInput;

        // ���� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ���� ȸ�� ó��
        if (turnInput != 0)
        {
            // ȸ���� ���� ���� ���
            Vector3 turnDirection = new Vector3(0, turnInput, 0);
            Quaternion turnRotation = Quaternion.Euler(turnDirection * turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * turnRotation, turnSpeed * Time.deltaTime);
        }
    }
}

    


