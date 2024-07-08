using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainOpen : MonoBehaviour
{
    public GameObject curtainL;
    public GameObject curtainR;

    public Transform closePosL;
    public Transform closePosR;

    public float moveSpeed = 2.0f;

    public GameObject flash;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            // 플레이어가 트리거 영역 안에 들어오면 
            //커튼이 좌우로 열린다.
            curtainR.transform.position = Vector3.Lerp(curtainR.transform.position, closePosR.position, Time.deltaTime);
            curtainL.transform.position = Vector3.Lerp(curtainL.transform.position, closePosL.position, Time.deltaTime);
            //스포트라이트가 활성화된다
            flash.SetActive(true);
        }
    }
}
