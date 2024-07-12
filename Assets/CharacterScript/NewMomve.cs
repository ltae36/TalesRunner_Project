using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMomve : MonoBehaviour
{

    float x;
    float v;

    Vector3 characterMove;

    Rigidbody rb;
    //Animator ani;

    public float walkSpeed = 10f;
    public float runSpeed = 30f;
    public float jumpHeight = 30f;
    public float doubleJumpHeight = 30f;
    public float slideSpeed = 50f;


    public bool isWalk;
    public bool isRun;
    public bool isJump;
    public bool isDoubleJump;
    public bool isSlide;
    public bool isGround;

    public int jumpCount = 2;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ani = GetComponent<Animator>();
    }

    void Update()
    {





    }

    void walkAndRun()
    {
        x = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 characterMove = new Vector3(x, 0f, v);

        transform.position += characterMove * walkSpeed * Time.deltaTime; 

       


    }

    

    

    void Jump()
    {

    }

    void doubleJump()
    {

    }





}
