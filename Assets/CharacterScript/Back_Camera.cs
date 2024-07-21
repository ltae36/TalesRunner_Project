using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Back_Camera : MonoBehaviour
{
    public Transform character; // ĳ������ Transform�� ���⿡ �Ҵ�
    public Vector3 offset = new Vector3(0f, 2f, -5f); // ī�޶��� ����� ��ġ(offset) ����

    void LateUpdate()
    {
        if (character != null)
        {
            // ĳ������ ��ġ�� offset�� ���� ī�޶��� ���ϴ� ��ġ�� �̵���ŵ�ϴ�.
            transform.position = character.position + offset;

            // ĳ������ ȸ�� ���� �����ͼ� �׿� ���߾� ī�޶� ȸ���մϴ�.
            transform.rotation = character.rotation;

            // ĳ���͸� �ٶ󺸵��� ī�޶��� ������ �����մϴ�.
            transform.LookAt(character);

        }
    }
}
