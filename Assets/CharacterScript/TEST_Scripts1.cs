using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Scripts1 : MonoBehaviour
{
    public float moveSpeed = 5f;            // 이동 속도
    public float runSpeed = 10f;            // 달리기 속도
    public float rotationSpeed = 3f;        // 회전 속도
    public float jumpForce = 10f;           // 점프 힘
    public float slideSpeed = 50f;

    private Animator animator;              // 애니메이터 컴포넌트
    private Rigidbody rb;

    private bool isGrounded;                // 땅에 있는지 여부
    private bool isRunning;                 // 달리기 중인지 여부
    private bool isJumping;                 // 점프 중인지 여부
    private bool isDoubleJumping;           // 이단점프 중인지 여부
    private bool isSliding;

    private int jumpsRemaining;             // 남은 점프 횟수
    private const int maxJumps = 2;         // 최대 점프 횟수

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        isGrounded = true;
        isRunning = false;
        isJumping = false;
        isDoubleJumping = false;
        isSliding = false;
        jumpsRemaining = maxJumps;
    }

    void Update()
    {

        // 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 회전
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        }

        // 방향키 입력에 따라 회전
        if (horizontalInput != 0 || verticalInput != 0)
        {
            // 입력된 방향 계산
            Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);

            // 이동
            if (verticalInput != 0)
            {
                transform.Translate(transform.forward * verticalInput * moveSpeed * Time.deltaTime, Space.World);
            }

            Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);

            //if (Input.GetKey(KeyCode.LeftShift)) // 달리기 , 애니메이션
            //{
            //    transform.Translate(moveDirection * runSpeed * Time.deltaTime, Space.World);
            //    //animator.SetBool("Run", true);
            // 달리기 체크
            isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            // 점프 및 이단점프 체크
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    Jump();
                }
                else if (!isDoubleJumping && jumpsRemaining > 0)
                {
                    DoubleJump();
                }
            }

            // 달리기면 달리기 속도 / 아니면 걷기
            float currentSpeed = isRunning ? runSpeed : moveSpeed;
            Vector3 movementVelocity = move * currentSpeed * Time.deltaTime;




            // Raycast로 경사면 감지 및 슬라이딩
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1.0f))
            {
                if (IsSlideSurface(hitInfo.collider))
                {
                    // 경사면의 노말 벡터를 이용하여 슬라이딩 방향을 설정
                    Vector3 slopeNormal = hitInfo.normal;
                    Vector3 slideDirection = Vector3.ProjectOnPlane(move, slopeNormal).normalized;
                    movementVelocity = slideDirection * slideSpeed * Time.deltaTime;
                    isSliding = true;
                }
                else
                {
                    isSliding = false;
                }
            }
            else
            {
                isSliding = false;
            }


            UpdateAnimator(move);
        }

        void Jump()
        {
            isGrounded = false;
            isJumping = true;
            animator.SetTrigger("IsJumping");
            animator.SetBool("IsSliding", false);
            jumpsRemaining--;

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        void DoubleJump()
        {
            isDoubleJumping = true;
            animator.SetBool("IsDoubleJumping", true);
            jumpsRemaining--;

            rb.velocity = Vector3.zero;  // 현재 속도를 초기화
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        void UpdateAnimator(Vector3 movement)
        {
            animator.SetFloat("Speed", movement.magnitude);
            animator.SetBool("IsRunning", isRunning);
        }

        bool IsSlideSurface(Collider collider)
        {
            // 여기서는 예시로 Collider의 태그를 사용하여 슬라이딩 지형을 판단합니다.
            return collider.CompareTag("Slide");
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("CameraSwap"))
            {
                isGrounded = true;
                isJumping = false;
                isDoubleJumping = false;
                isSliding = false;
                jumpsRemaining = maxJumps;
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsDoubleJumping", false);
                animator.SetBool("IsSliding", false);
            }
            else if (collision.gameObject.CompareTag("Slide"))
            {
                isGrounded = true;
                isJumping = false;
                isDoubleJumping = false;
                jumpsRemaining = maxJumps;
                isSliding = true;
                animator.SetBool("IsSliding", true);
            }
        }
    }
}


        

        
        



    


