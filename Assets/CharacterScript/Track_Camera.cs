using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Track_Camera : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (ĳ����)
    public float distance = 10f; // ī�޶�� ĳ���� ������ �Ÿ�
    public float height = 3f; // ī�޶��� ����
    

    void LateUpdate()
    {
        if (target == null) return; // ����� ������ �Լ� ����

        // Ÿ�� ��ġ�� ������ ������� ī�޶��� ��ġ ���
        Vector3 targetPosition = target.position + Vector3.up * height - target.forward * distance;

        // ī�޶��� ��ġ ����
        transform.position = targetPosition;

        // Ÿ���� �ٶ󺸵��� ī�޶� ȸ��
        transform.LookAt(target.position);
    }
}