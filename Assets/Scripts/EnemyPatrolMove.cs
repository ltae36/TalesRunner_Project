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
        #region 패트롤 이동, 방향 전환
        // 나의 위치가 포인트의 current번째 위치가 아니라면
        if (transform.position != points[current].position)
        {
            // 포인트를 따라 계속해서 이동
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, moveSpeed * Time.deltaTime);

            // 나의 방향을 포인트의 방향으로 전환
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
