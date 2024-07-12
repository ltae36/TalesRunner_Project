using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Back_Camera : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (ĳ����)

    public Vector3 offset = new Vector3(0f, 3f, -10f); // ī�޶�� ĳ���� ������ �Ÿ� �� ��ġ ����

    public float smoothSpeed = 0.125f; // ī�޶� �̵��� �ε巴�� �ϱ� ���� �ӵ�

    void LateUpdate()
    {
        if (target == null) return; // ����� ������ �Լ� ����

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;




        transform.LookAt(target.position); // ī�޶� ĳ���͸� �ٶ󺸵��� ��
    }
}
