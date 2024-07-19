using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotTrigger : MonoBehaviour
{
    // 스포트라이트가 켜진 상태에서 플레이어가 트리거 영역 안에 들어오면
    // 플레이어는 이동불능 상태인 목각인형 디버프에 걸려 빙글빙글돌며 움직이지 못하게 된다.
    // 일정 시간이 흐르면 다시 움직일 수 있게 된다.
    public GameObject flash;
    public GameObject player;
    public float stopDuration = 5.0f; // 플레이어가 멈추는 시간

    float currentTime; // 플레이어가 목각인형이 되어있는 시간
    bool canMove;
    Final playerMove;

    //Final playerMove = new Final();

    void Start()
    {
        canMove = true;
    }

    void Update()
    {        
       // canMove가 true라면 플레이어는 이동이 가능함
       // canMove가 false라면 플레이어는 목각인형이 되어 moveSpeed가 0이 됨.
    }


    private void OnTriggerEnter(Collider other)
    {
        if (flash.activeInHierarchy)
        {
            print("스포트라이트에 닿았다!");
            //playerMove = player.GetComponent<Final>();
            player.transform.position = transform.position;
        }
    }
}
