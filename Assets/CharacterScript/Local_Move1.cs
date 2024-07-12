using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_Move : MonoBehaviour
{
    public float moveSpeed = 5f;            // 이동 속도
    public float runSpeed = 10f;            // 달리기 속도
    public float rotationSpeed = 10f;       // 회전 속도
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
        // 이동 입력 처리
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        // 캐릭터의 로컬 방향으로 이동 방향 설정
        Vector3 localMoveDirection = transform.TransformDirection(movement);

        // 이동 방향으로 회전
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

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

        // 이동과 달리기에 따른 속도 계산
        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        Vector3 movementVelocity = localMoveDirection * currentSpeed * Time.deltaTime;

        // Rigidbody의 위치를 로컬 좌표계 기준으로 이동시킴
        rb.MovePosition(rb.position + movementVelocity);

        // 이동과 슬라이딩 속도 적용
        float currentSpeed2 = isSliding ? slideSpeed : moveSpeed;
        Vector3 movementVelocity2 = localMoveDirection * currentSpeed2 * Time.deltaTime;
        rb.MovePosition(rb.position + movementVelocity2);

        // 애니메이션 업데이트
        UpdateAnimator(movement);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //|| collision.gameObject.CompareTag("CameraSwap"))
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