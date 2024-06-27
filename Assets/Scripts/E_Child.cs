using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Child : MonoBehaviour
{
    public float moveSpeed = 10;
    private bool isStop = true;
    float currentTime = 0;
    float downTime = 1.5f;

    //넘어지는 애니메이션 재생

    void Start()
    {
        // 애니메이터 컴포넌트를 가져온다
    }

    void Update()
    {
        if(isStop == true)
        {
            // 이동 공식 : p = p0 +vt
            transform.position += new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;

            
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
    // 만일 플레이어와 부딪히면 넘어진다
    

    // 넘어 지면 잠깐 멈췄다가 일어나서 다시 뛰어다닌다.
    private void OnTriggerEnter(Collider other)
    {
        isStop = false;
    }


}
