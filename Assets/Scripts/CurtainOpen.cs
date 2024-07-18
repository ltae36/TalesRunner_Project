using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainOpen : MonoBehaviour
{
    public GameObject curtainL;
    public GameObject curtainR;

    public Transform openL;
    public Transform openR;

    public float moveSpeed = 2.0f;

    public GameObject flash;

    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            // 플레이어가 트리거 영역 안에 들어오면 
            //커튼이 좌우로 열린다.
            curtainR.transform.localScale = Vector3.Lerp(curtainR.transform.localScale, openR.localScale, Time.deltaTime * moveSpeed);
            curtainL.transform.localScale = Vector3.Lerp(curtainL.transform.localScale, openL.localScale, Time.deltaTime * moveSpeed);
            //스포트라이트가 활성화된다
            flash.SetActive(true);
        }
    }
}
