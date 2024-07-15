using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Child : MonoBehaviour
{
    public float moveSpeed = 10;
    public GameObject player;

    //public Transform[] goals;

    bool isStop = true;
    bool triggerCheck = false;

    float currentTime = 0;
    float downTime = 1.5f;
    float rot;

    int randomRot = 35;
    
    Vector3 dir = new Vector3(1, 0, 0);
    

    void Start()
    {
    }

    void Update()
    {
        if (isStop == true)
        {
            // �̵� ���� : p = p0 +vt

            transform.position += dir * moveSpeed * Time.deltaTime;
            dir.Normalize();

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
        //int i = 0;
        //while (i < goals.Length)
        //{
        //    dir = goals[i].transform.position - transform.position;
        //    if (isStop == true)
        //    {
        //        // �̵� ���� : p = p0 +vt

        //        transform.position += dir * moveSpeed * Time.deltaTime;
        //        dir.Normalize();

        //        // ������ �������� ��� �׸��� �پ�ٴѴ�.

        //        // ���� ����ų� �����ڽ��� �ε��� �� ���ٸ�, ������ �����Ѵ�.
        //    }
        //    else
        //    {
        //        currentTime += Time.deltaTime;
        //        if (currentTime > downTime)
        //        {
        //            isStop = true;
        //        }
        //    }
        //    if(transform.position == goals[i].transform.position) 
        //    {
        //        i++;
        //    }
        //}


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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall") 
        {
            triggerCheck = true;
            transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
            dir = new Vector3(1, 0, 0);
            print(triggerCheck);
        }                
    }
}
