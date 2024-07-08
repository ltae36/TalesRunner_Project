using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Scripts : MonoBehaviour
{
    public float moveSpeed = 5f;            // �̵� �ӵ�
    public float runSpeed = 10f;            // �޸��� �ӵ�
    public float rotationSpeed = 3f;        // ȸ�� �ӵ�
    public float jumpForce = 10f;           // ���� ��
    public float slideSpeed = 50f;

    private Animator animator;              // �ִϸ����� ������Ʈ
    private Rigidbody rb;

    private bool isGrounded;                // ���� �ִ��� ����
    private bool isRunning;                 // �޸��� ������ ����
    private bool isJumping;                 // ���� ������ ����
    private bool isDoubleJumping;           // �̴����� ������ ����
    private bool isSliding;

    private int jumpsRemaining;             // ���� ���� Ƚ��
    private const int maxJumps = 2;         // �ִ� ���� Ƚ��

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
        // �̵� 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        // ĳ������ ���� �������� �̵� ���� ����
        Vector3 localMoveDirection = transform.TransformDirection(movement);

        // �̵� �������� ȸ��
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // �޸��� üũ
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // ���� �� �̴����� üũ
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

        // �޸���� �޸��� �ӵ� / �ƴϸ� �ȱ�
        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        Vector3 movementVelocity = localMoveDirection * currentSpeed * Time.deltaTime;

        // Raycast�� ���� ���� �� �����̵�
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1.0f))
        {
            if (IsSlideSurface(hitInfo.collider))
            {
                // ������ �븻 ���͸� �̿��Ͽ� �����̵� ������ ����
                Vector3 slopeNormal = hitInfo.normal;
                Vector3 slideDirection = Vector3.ProjectOnPlane(localMoveDirection, slopeNormal).normalized;
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

        // Rigidbody�� ��ġ�� ���� ��ǥ�� �������� �̵���Ŵ
        rb.MovePosition(rb.position + movementVelocity);

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

        rb.velocity = Vector3.zero;  // ���� �ӵ��� �ʱ�ȭ
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void UpdateAnimator(Vector3 movement)
    {
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetBool("IsRunning", isRunning);
    }

    bool IsSlideSurface(Collider collider)
    {
        // ���⼭�� ���÷� Collider�� �±׸� ����Ͽ� �����̵� ������ �Ǵ��մϴ�.
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
    

        

        
        



    


