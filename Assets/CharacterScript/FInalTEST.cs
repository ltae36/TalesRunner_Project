using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class FInalTEST : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터의 이동 속도
    public float rotationSpeed = 150f; // 캐릭터의 회전 속도
    Vector3 moveDirection;

    public float walkSpeed = 5f;
    public float runSpeed = 20f;
    public float slideSpeed = 30f;

    public float jumpHeight = 20f;
    public float doubleJumpHeight = 20f;  // 이단 점프 힘

    //public int maxJumpCount = 2;  // 최대 점프 횟수
    private int jumpCount = 2;



    //public float groundCheckDistance = 0.1f;  // 땅 감지 거리
    //public LayerMask Ground;  // 그라운드 레이어
    //public LayerMask Slide; // 슬라이드 레이어

    public float rayLength = 2f;



    public float pushForce = 40f; // trap에 부딪히면 밀쳐낼 힘

    //public Vector3 pushDirection = Vector3.back; // 밀쳐낼 방향 / 뒤
    public Vector3 pushDirection;// 밀쳐낼 방향 / 뒤



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

        float moveInput = Input.GetAxis("Vertical"); // W/S 또는 상하 방향키 입력
        float turnInput = Input.GetAxis("Horizontal"); // A/D 또는 좌우 방향키 입력

        // 이동 방향 계산
        Vector3 moveDirection = transform.forward * moveInput;

        // 차량 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 차량 회전 처리
        if (turnInput != 0)
        {
            // 회전할 방향 벡터 계산
            Vector3 turnDirection = new Vector3(0, turnInput, 0);

            // 목표 회전 각도 계산
            Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + turnInput * rotationSpeed * Time.deltaTime, 0);

            // 즉시 회전
            transform.rotation = targetRotation;
        }





            if (moveDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed = runSpeed;

                    transform.position += moveDirection * moveSpeed * Time.deltaTime;
                    animator.SetFloat("Speed", runSpeed); // 달리기 애니메이션 입력

                    audioSource.clip = soundRun;
                    audioSource.Play();


                }
                else
                {
                    moveSpeed = walkSpeed;

                    transform.position += moveDirection * moveSpeed * Time.deltaTime;
                    animator.SetFloat("Speed", walkSpeed); // 걷기 애니메이션 입력
                }
            }
            else
            {
                // 플레이어가 멈춰 있을 때
                animator.SetFloat("Speed", 0f); // "Speed" 파라미터를 0으로 설정하여 Idle 상태로 전환  
            }



            // 레이캐스트를 사용해 Slide태그 경사면 이동/슬라이딩 자연스럽게


            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit Hit, rayLength))      // 만약, 레이캐스트에서 경사면을 인식한다면
            {

                Vector3 slopeNormal = Hit.normal;

                if (Hit.collider.CompareTag("Slide"))
                {
                    Vector3 slopeDirection = Vector3.ProjectOnPlane(moveDirection, slopeNormal).normalized;

                    transform.position += slopeDirection * slideSpeed * Time.deltaTime;  // 경사면 속도로

                    //Quaternion slopeRotation = Quarternion.FromtoRotation(Vector3.up )

                }
                else
                {
                    transform.position += moveDirection * moveSpeed * Time.deltaTime;  // 경사면이 아니라면 일반 속도로
                }
            }










            if (Input.GetKeyDown(KeyCode.Space))  // 점프
            {
                if (jumpCount == 2)
                {
                    // 첫 번째 점프
                    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                    animator.SetTrigger("Jump");    // 점프 애니메이션 실행
                    animator.SetBool("Slide", false);  // 슬라이드는 출력 x


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

                }

                //if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))    // 대시누르는 상태로 + 점프 할때도 소리 출력해야 함 
                //{
                //    if (jumpCount == 2)
                //    {
                //        // 첫 번째 점프
                //        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                //        animator.SetTrigger("Jump");
                //        animator.SetBool("Slide", false);
                //        audioSource.clip = soundJump;
                //        audioSource.Play();
                //        jumpCount--;
                //    }
                //    else if (jumpCount == 1)
                //    {
                //        // 두 번째 점프 (이중 점프)
                //        rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);

                //        animator.SetTrigger("DoubleJump");
                //        animator.SetBool("Slide", false);
                //        audioSource.clip = soundDoubleJump;
                //        audioSource.Play();
                //        jumpCount--;

                //    }
            }
        }
 







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


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))  // trap 태그의 오브젝트에 닿고
        {
            if (rb != null)   // 리지드 바디가 null값이 아니라면
            {
                pushDirection = new Vector3(0f, 5f, -5f); // 밀쳐낼 방향 설정

                //animator.SetTrigger

                rb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);  // 밀쳐내라

            }
        }
    }





    public IEnumerator BoostSpeed(float boost, float boostTime)
    {
        float originalSpeed = moveSpeed; // 오리지날 스피드에 원래 이동속도를 넣는다

        moveSpeed += boost; // 이동 속도에 발판 부스트 속도를 더한다.
        Debug.Log("Speed increased to {moveSpeed}.");



        yield return new WaitForSeconds(boostTime);  // 부스트 시간이 지난후 리턴하고 기다린다.

        Debug.Log("원래속도로 돌아갑니다 속도 부스트 끝.");
        moveSpeed = originalSpeed;  // 원래속도로 다시 돌려놓는다

    }

}

