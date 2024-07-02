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
            // 이동 공식 : p = p0 +vt
            
            transform.position += dir * moveSpeed * Time.deltaTime;
                        
            // 무작위 방향으로 곡선을 그리며 뛰어다닌다.

            // 길을 벗어나거나 나무박스에 부딪힐 것 같다면, 방향을 변경한다.
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

    // 다른 오브젝트와 맞닥뜨렸을때
    // 플레이어라면 부딪혀서 넘어진다. 잠시 후에 다시 일어나서 달려간다
    // 나무상자라면 방향을 바꿔서 피해간다
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
