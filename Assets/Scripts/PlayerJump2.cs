using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump2 : MonoBehaviour
{
    private Rigidbody rigid; // 물리 선언

    public float jumpForce;

    bool isGround;   // bool 기본은 false , 공중에서 무한점프가 되지않게 추가





    void Start()
    {
        rigid = GetComponent<Rigidbody>(); // Rigidbody 게임 어포넌트를 rigid에 담는다.

    }

    void Update() // 만든 액션 함수들을 update 에 입력
    {
        Jump();
        

    }



    void Jump() // space 를 누르면 , 점프(rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse) 를 한다.
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 점프높이는 전역변수 jumpForce로 조정가능
        //}
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        isGround = false;

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }
          private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }






}

   

   
    

   
        
 