using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Camera : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (ĳ����)
    public float distance = 5f; // ī�޶�� ĳ���� ������ �Ÿ�
    public float height = 2f; // ī�޶��� ����

    void Update()
    {
        // ĳ���Ͱ� �ٶ󺸴� ����(normalized)�� �������� ī�޶� ȸ����ŵ�ϴ�.
        Vector3 lookDirection = target.forward;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

        // ī�޶��� ȸ���� �ε巴�� ����
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }




    //if (target != null)
    //{
    //    // ĳ������ ��ġ�� ���� �ڷ� �̵��ϰ� ���� �ø� ��ġ ���
    //    Vector3 offset = -target.forward * distance + Vector3.up * height;
    //    // ī�޶��� ��ġ�� ���� ��ġ�� ����
    //    transform.position = target.position + offset;

    //    // ĳ���Ͱ� �ٶ󺸴� �������� ī�޶� ȸ��
    //    transform.rotation = Quaternion.LookRotation(target.forward, Vector3.up);
    //}
}
