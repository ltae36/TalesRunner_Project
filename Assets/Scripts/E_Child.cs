using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Child : MonoBehaviour
{
    public float moveSpeed = 10;
    private bool isStop = true;
    float currentTime = 0;
    float downTime = 1.5f;
    public GameObject player;
    Vector3 dir = new Vector3(0, 0, 1);


    void Start()
    {
    }

    void Update()
    {
        if(isStop == true)
        {
            // �̵� ���� : p = p0 +vt
            
            transform.position += dir * moveSpeed * Time.deltaTime;
                        
            // ������ �������� ��� �׸��� �پ�ٴѴ�.

            // ���� ����ų� �����ڽ��� �ε��� �� ���ٸ�, ������ �����Ѵ�.
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime > downTime)
            {
                isStop = true;
            }
        }

    }

    // �ٸ� ������Ʈ�� �´ڶ߷�����
    // �÷��̾��� �ε����� �Ѿ�����. ��� �Ŀ� �ٽ� �Ͼ�� �޷�����
    // �������ڶ�� ������ �ٲ㼭 ���ذ���
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.name == "Player")
        {
            isStop = false;
        }
        else
        {
            dir = new Vector3(1, 0, 0);
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }


}
