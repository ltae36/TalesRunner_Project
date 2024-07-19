using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrolMove : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 10;
    public static EnemyPatrolMove enemyPatrol;
    
    int current;    

    Vector3 dir;


    void Start()
    {
        current = 0;
        
    }

    private void Awake()
    {
        if(enemyPatrol == null) 
        {
            enemyPatrol = this;
        }
    }

    void Update()
    {
        #region ��Ʈ�� �̵�, ���� ��ȯ
        // ���� ��ġ�� ����Ʈ�� current��° ��ġ�� �ƴ϶��
        if (transform.position != points[current].position)
        {
            // ����Ʈ�� ���� ����ؼ� �̵�
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, moveSpeed * Time.deltaTime);

            // ���� ������ ����Ʈ�� �������� ��ȯ
            dir = points[current].transform.position - transform.position;
            dir.Normalize();

            Quaternion rot = Quaternion.LookRotation(dir, transform.up);
            transform.rotation = rot;
        }
        else 
        {
            current = (current + 1) % points.Length;
        }
        #endregion
        
    }

}
