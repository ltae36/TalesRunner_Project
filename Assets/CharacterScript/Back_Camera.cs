using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Back_Camera : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (ĳ����)

    public Vector3 offset = new Vector3(0f, 3f, -10f); // ī�޶�� ĳ���� ������ �Ÿ� �� ��ġ ����


    void LateUpdate()
    {
        if (target == null) return; // ����� ������ �Լ� ����

        
        transform.position = target.position + offset; // Ÿ�� ��ġ�� offset�� ���Ͽ� ī�޶��� ��ġ ����

        
        transform.LookAt(target.position); // Ÿ���� �ٶ󺸵��� ī�޶� ȸ��



    }
}
