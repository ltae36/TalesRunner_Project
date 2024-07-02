using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotTrigger : MonoBehaviour
{    
    public GameObject go;

    public float stopDuration = 5.0f; // 플레이어가 멈추는 시간
    float currentTime;
    PlayerMove move = new PlayerMove();

    void Start()
    {
        move.canMove = true;
    }

    void Update()
    {
       if(move.canMove == false) 
        {
            currentTime += Time.deltaTime;
            print(currentTime);
            if(currentTime > stopDuration) 
            {
                go.GetComponent<PlayerMove>().canMove = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // 스포트라이트에 닿으면 목각인형 상태가 되어 조작할 수 없게 된다.
        if(other.gameObject.tag == "Player") 
        {
            print("스포트라이트에 닿았다!");
            other.GetComponent<PlayerMove>().canMove = false;
            move.canMove = false;
        }
    }
}
