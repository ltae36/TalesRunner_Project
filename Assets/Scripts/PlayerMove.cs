using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour // 플레이어 앞뒤좌우 이동
{
    float h;
    float v;

    public float playerSpeed = 20;

    Vector3 move;



    void Start()  // 처음 시작때 한 번 출력 
    {
        
    }

    void Update() //
    {
        


    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //Vector3 move = new Vector3(h, 0, v);

        //transform.position = transform.position * playerSpeed * Time.deltaTime; // p = p0 * vt
        transform.position += move * playerSpeed * Time.deltaTime; // p = p0 * vt


        this.move = new Vector3(h, 0, v).normalized; //moveVec.Normalize(); 대신 뒤에 .normailzed 를 붙여도 됨. move 앞에 this를 붙여서 전역변수를 가져옴
    }
}
