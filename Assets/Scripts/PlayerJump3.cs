using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump3 : MonoBehaviour
{

   


    public Rigidbody rigid;
    public bool PlayerGround = false; // 기본형 false

    public float moveSpeed = 10f;
    public float jumpHeight = 10f;

  

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
       
    }

    void Update()
    {
        Jump();
        Move();
    }


    #region 일반 점프 바닥충돌
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerGround = false;
        }



    }
    #endregion

    //private void OnCollisionExit(Collision collision)
    //{
    //    if(collision.transform.tag != null)
    //    {
    //        PlayerGround = false;
    //    }
    //}



    void Jump()
    {

        #region 일반 점프 
        if (Input.GetButtonDown("Jump") && !PlayerGround) //true, 점프 만들기
        {
            //rigid.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            PlayerGround = true;
        }
        #endregion
                        


    }

    void Move()
    {
        // translate 를 이용한 방법
        //float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //transform.Translate(h, 0, v);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moving = new Vector3(h, 0, v);

        transform.position += moving * moveSpeed * Time.deltaTime;
        moving.Normalize();

        
    }


}
