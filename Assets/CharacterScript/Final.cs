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
    public float rotationSpeed = 10f; // 캐릭터의 회전 속도
    Vector3 localMoveDirection;

    public float walkSpeed = 5f;
    public float runSpeed = 20f;
    public float slideSpeed = 30f;

    public float jumpHeight = 20f;
    public float doubleJumpHeight = 20f;  // 이단 점프 힘

    //public int maxJumpCount = 2;  // 최대 점프 횟수
    private int jumpCount = 2;
    public float pushForce = 20f;  // 트랩에 부딪히면 밀쳐질 거리/힘


    //public float groundCheckDistance = 0.1f;  // 땅 감지 거리
    //public LayerMask Ground;  // 그라운드 레이어
    //public LayerMask Slide; // 슬라이드 레이어

    public float rayLength = 10f;


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


        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // 월드 좌표값


        if (movement.magnitude > 0.1f)   // 이동 방향 벡터의 길이가 일정 값보다 크면 회전 및 이동합니다
        {

            Vector3 localMoveDirection = transform.TransformDirection(movement); // 월드좌표값을 로컬 좌표로 변환


            Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection); // 이동 방향으로 회전을 계산합니다


            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);   // 부드럽게 회전하기 위해 Lerp를 사용합니다

            //transform.position += transform.forward * moveSpeed * Time.deltaTime; // 이동 방향을 기반으로 캐릭터를 이동시킵니다

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += localMoveDirection * runSpeed * Time.deltaTime;
                animator.SetFloat("Speed", runSpeed); // 달리기 애니메이션 입력

                audioSource.clip = soundRun;
                audioSource.Play();
            }
            else
            {
                transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed); // 걷기 애니메이션 입력
            }
        }
        else
        {
            // 플레이어가 멈춰 있을 때
            animator.SetFloat("Speed", 0f); // "Speed" 파라미터를 0으로 설정하여 Idle 상태로 전환  
        }



        //if (movement.magnitude > 0.1f)
        //{
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        transform.position += localMoveDirection * runSpeed * Time.deltaTime;
        //        animator.SetFloat("Speed", runSpeed); // 달리기 애니메이션 입력

        //        audioSource.clip = soundRun;
        //        audioSource.Play();


        //    }
        //    else
        //    {
        //        transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
        //        animator.SetFloat("Speed", walkSpeed); // 걷기 애니메이션 입력
        //    }
        //}
        //else
        //{
        //    // 플레이어가 멈춰 있을 때
        //    animator.SetFloat("Speed", 0f); // "Speed" 파라미터를 0으로 설정하여 Idle 상태로 전환  
        //}









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
                    Vector3 slopemovement = Vector3.ProjectOnPlane(localMoveDirection, slopenormal).normalized;


                    transform.position += slopemovement * slideSpeed * Time.deltaTime;  // 경사면움직임으로

                    // 경사면에 따른 회전 처리 (옵션)
                    // Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.up, slopeNormal);
                    // transform.rotation = slopeRotation;
                }
                else
                {
                    transform.position += localMoveDirection * moveSpeed * Time.deltaTime;  // 경사면이 아니라면 일반 움직임으로
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

            transform.position += localMoveDirection * slideSpeed * Time.deltaTime;
            animator.SetBool("Slide", true);
        }



        if (collision.gameObject.CompareTag("Trap"))    // trap에 부딪히면
        {

            //animator.SetBool("TrapFall", true); //  애니메이션을 재생하고

            //animator.SetBool("TrapGetup", true); //  애니메이션을 재생하고

            //rb.isKinematic = true;   // rigidbody의 iskinetic을 활성화하고  

            Debug.Log("닿음");

            // 넉백 방향 설정
            Vector3 knockBackDirection = transform.position - collision.transform.position;
            knockBackDirection.y = 0f; // 수직 방향으로는 넉백하지 않도록 설정

            // 넉백 힘 추가
            rb.AddForce(knockBackDirection.normalized * pushForce, ForceMode.Impulse);

        }

    }
}