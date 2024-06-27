using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump3 : MonoBehaviour
{

   


    public Rigidbody rigid;
    public bool PlayerGround; // 기본형 false

    public float moveSpeed = 10f;
    public float jumpHeight = 10f;

    public int jumpPossible;
    int jumpCount;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        jumpCount = jumpPossible;
    }

    void Update()
    {
        Jump();
        Move();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            PlayerGround = false;
        }
    }
   
    void Jump()
    {
        

        if (Input.GetButtonDown("Jump") && !PlayerGround) //true
        {
            //rigid.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            PlayerGround = true;
        }

        //if(Input.GetButtonDown("Jump") && jumpCount > 0)
        //{
        //    Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpHeight * -Physics.gravity.y);
        //    rigid.AddForce(jumpVelocity, ForceMode.Impulse);
        //    jumpCount--;
       
        //}


    }

    void Move()
    {
        // translate 를 이용한 방법
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(h, 0, v);            
        
        
    }


}
