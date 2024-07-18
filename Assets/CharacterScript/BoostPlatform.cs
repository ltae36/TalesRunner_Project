using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    public float boost = 5f;  // 부스트 추가속도
    public float boostTime = 3f;  //부스트 시간 3초


    void Start()
    {
        
    }

    void Update()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Final playerMovement = other.GetComponent<Final>(); // Fianl의 playermovent 변수 선언


            if(playerMovement != null)
            {
                Debug.Log("플레이어가 발판에 닿았습니다. 속도 부스트 시작.");
                playerMovement.StartCoroutine(playerMovement.BoostSpeed(boost, boostTime));  // 이 오브젝트를 "플레이어" 태그의 게임오브젝트가 밟으면 Final 스크립트에 속도추가를 요청
            }                                                                  // BoostSpeed 함수는 Final 스크립트에 있다.


        }

    }
}
