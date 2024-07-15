using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Camera : MonoBehaviour
{
    public Transform target; // ���� Ÿ�� (ĳ����)
    public Vector3 offset;   // ī�޶�� Ÿ�� ���� ������
    public float smoothSpeed = 0.125f; // �ε巯�� �̵� �ӵ�
    void Update()

    {

    }

    void LateUpdate()
    {
        // Ÿ���� ��ġ�� �������� ���� ��ġ ���
        Vector3 desiredPosition = target.position + offset;
        // �ε巴�� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // ī�޶� Ÿ���� ������ �ٶ󺸵��� ȸ��
        transform.LookAt(target);
    }
}