using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;


public class Final : MonoBehaviour
{

    public float moveSpeed = 5f; // 캐릭터의 이동 속도
    public float rotationSpeed = 100f; // 캐릭터의 회전 속도
    Vector3 moveDirection;

    public float walkSpeed = 5f;
    public float runSpeed = 20f;
    public float slideSpeed = 30f;

    public float jumpHeight = 20f;
    public float doubleJumpHeight = 20f;  // 이단 점프 힘

    //public int maxJumpCount = 2;  // 최대 점프 횟수
    private int jumpCount = 2;
    public float pushForce = 10f;  // 트랩에 부딪히면 밀쳐질 거리/힘


    //public float groundCheckDistance = 0.1f;  // 땅 감지 거리
    //public LayerMask Ground;  // 그라운드 레이어
    //public LayerMask Slide; // 슬라이드 레이어

    public float rayLength = 2f;


    AudioSource audioSource;

    public AudioClip soundRun;
    public AudioClip soundJump;
    public AudioClip soundDoubleJump;





    bool isGrounded = true;
    bool isSlide;

    Rigidbody rb;
    Animator animator;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        jumpCount = 2;

        isSlide = false;

    }

    void Update()
    {
        //캐릭터 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;



        if (moveDirection != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += moveDirection * runSpeed * Time.deltaTime;
                animator.SetFloat("Speed", runSpeed); // 달리기 애니메이션 입력

                audioSource.clip = soundRun;
                audioSource.Play();


            }
            else
            {
                transform.position += moveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed); // 걷기 애니메이션 입력
            }
        }
        else
        {
            // 플레이어가 멈춰 있을 때
            animator.SetFloat("Speed", 0f); // "Speed" 파라미터를 0으로 설정하여 Idle 상태로 전환  
        }



        // 캐릭터 회전

        Vector3 lookDirection = new Vector3(horizontalInput, 0f, verticalInput);    // 캐릭터가 보는방향 = 회전방향 

        if (lookDirection != Vector3.zero) // 만약 보는 뱡향이 0값이 아니라면
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);    // 목표 방향으로 회전 , 회전각도 함수

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);   // 부드럽게 회전할때 Slerp 사용
        }






        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount == 2)
            {
                // 첫 번째 점프
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                animator.SetTrigger("Jump");
                animator.SetBool("Slide", false);
                audioSource.clip = soundJump;
                audioSource.Play();
                jumpCount--;
            }
            else if (jumpCount == 1)
            {
                // 두 번째 점프 (이중 점프)
                rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);

                animator.SetTrigger("DoubleJump");
                animator.SetBool("Slide", false);
                audioSource.clip = soundDoubleJump;
                audioSource.Play();
                jumpCount--;



                #region 레이캐스트/ 레이어를 이용한 점프, 그라운드를 벗어나면 점프가 안되서 사용x 레이캐스트를 아래가 아니라 앞뒤좌우 로 넓게 뿌려야함
                // 점프


                // isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, Ground);     // 땅에 닿아 있는지 확인 버그로 oncollision 사용하기로 함

                //if (isGrounded)
                //{
                //    jumpCount = 0;  // 땅에 있으면 점프 횟수 초기화
                //}
                //if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)  // 스페이스 누르면 점프  && 점프카운트가 맥스 점프카운트보다 적다면 
                //{
                //    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                //    animator.SetTrigger("Jump");

                //}      

                //if (Input.GetButtonDown("Jump") && jumpCount == 1)  // 만약 점프 버튼을 누르고 점프카운트가 1이면 한번 더 점프
                //{
                //    rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
                //    animator.SetTrigger("DoubleJump");


                //}
                //jumpCount++;
                #endregion

                if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayLength))      // 만약, 레이캐스트에서 경사면을 인식한다면
                {

                    Vector3 slopenormal = hit.normal;
                    Vector3 slopemovement = Vector3.ProjectOnPlane(moveDirection, slopenormal).normalized;


                    transform.position += slopemovement;  // 경사면움직임으로

                    //quaternion sloperotation = quarternion.fromtorotation(vector3.up )
                }
                else
                {
                    transform.position += moveDirection * moveSpeed * Time.deltaTime;  // 경사면이 아니라면 일반 움직임으로
                }
            }
        }



    }
      



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))       // Ground 태그에 닿으면 
        {
            jumpCount = 2;  // 지면에 닿으면 점프 횟수 초기화
        }


        if (collision.gameObject.CompareTag("Slide"))        // Slide 태그에 닿으면
        {

            jumpCount = 2;

            transform.position += moveDirection * slideSpeed * Time.deltaTime;
            animator.SetBool("Slide", true);
        }



        if (collision.gameObject.CompareTag("Trap"))    // trap에 부딪히면
        {

            //animator.SetBool("TrapFall", true); //  애니메이션을 재생하고

            //animator.SetBool("TrapGetup", true); //  애니메이션을 재생하고

            //rb.isKinematic = true;   // rigidbody의 iskinetic을 활성화하고  



            

            Debug.Log("닿음");
            //Vector3 knockBack = new Vector3(0, 1f, 1f).normalized;
            Vector3 knockBack = (transform.position - collision.transform.position).normalized;   //  넉백시킬 방향을 선언하고


            rb.AddForce(knockBack * pushForce, ForceMode.Impulse);   //  넉백시킬 힘을 추가한다.

        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Trap")) // 벽과 충돌할 경우
    //    {
    //        Vector3 knockBack = (transform.position - other.transform.position).normalized;
    //        rb.AddForce(knockBack * pushForce, ForceMode.Impulse);
    //    }
    //}
}