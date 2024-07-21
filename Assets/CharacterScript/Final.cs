using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;


public class Final : MonoBehaviour
{

    public float moveSpeed = 5f; // ĳ������ �̵� �ӵ�
    public float rotationSpeed = 10f; // ĳ������ ȸ�� �ӵ�
    Vector3 localMoveDirection;

    public float walkSpeed = 5f;
    public float runSpeed = 20f;
    public float slideSpeed = 30f;

    public float jumpHeight = 20f;
    public float doubleJumpHeight = 20f;  // �̴� ���� ��

    //public int maxJumpCount = 2;  // �ִ� ���� Ƚ��
    private int jumpCount = 2;
    public float pushForce = 20f;  // Ʈ���� �ε����� ������ �Ÿ�/��


    //public float groundCheckDistance = 0.1f;  // �� ���� �Ÿ�
    //public LayerMask Ground;  // �׶��� ���̾�
    //public LayerMask Slide; // �����̵� ���̾�

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
        //ĳ���� �̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // ���� ��ǥ��


        if (movement.magnitude > 0.1f)   // �̵� ���� ������ ���̰� ���� ������ ũ�� ȸ�� �� �̵��մϴ�
        {

            Vector3 localMoveDirection = transform.TransformDirection(movement); // ������ǥ���� ���� ��ǥ�� ��ȯ


            Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection); // �̵� �������� ȸ���� ����մϴ�


            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);   // �ε巴�� ȸ���ϱ� ���� Lerp�� ����մϴ�

            //transform.position += transform.forward * moveSpeed * Time.deltaTime; // �̵� ������ ������� ĳ���͸� �̵���ŵ�ϴ�

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += localMoveDirection * runSpeed * Time.deltaTime;
                animator.SetFloat("Speed", runSpeed); // �޸��� �ִϸ��̼� �Է�

                audioSource.clip = soundRun;
                audioSource.Play();
            }
            else
            {
                transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed); // �ȱ� �ִϸ��̼� �Է�
            }
        }
        else
        {
            // �÷��̾ ���� ���� ��
            animator.SetFloat("Speed", 0f); // "Speed" �Ķ���͸� 0���� �����Ͽ� Idle ���·� ��ȯ  
        }



        //if (movement.magnitude > 0.1f)
        //{
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        transform.position += localMoveDirection * runSpeed * Time.deltaTime;
        //        animator.SetFloat("Speed", runSpeed); // �޸��� �ִϸ��̼� �Է�

        //        audioSource.clip = soundRun;
        //        audioSource.Play();


        //    }
        //    else
        //    {
        //        transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
        //        animator.SetFloat("Speed", walkSpeed); // �ȱ� �ִϸ��̼� �Է�
        //    }
        //}
        //else
        //{
        //    // �÷��̾ ���� ���� ��
        //    animator.SetFloat("Speed", 0f); // "Speed" �Ķ���͸� 0���� �����Ͽ� Idle ���·� ��ȯ  
        //}









        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount == 2)
            {
                // ù ��° ����
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                animator.SetTrigger("Jump");
                animator.SetBool("Slide", false);
                audioSource.clip = soundJump;
                audioSource.Play();
                jumpCount--;
            }
            else if (jumpCount == 1)
            {
                // �� ��° ���� (���� ����)
                rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);

                animator.SetTrigger("DoubleJump");
                animator.SetBool("Slide", false);
                audioSource.clip = soundDoubleJump;
                audioSource.Play();
                jumpCount--;



                #region ����ĳ��Ʈ/ ���̾ �̿��� ����, �׶��带 ����� ������ �ȵǼ� ���x ����ĳ��Ʈ�� �Ʒ��� �ƴ϶� �յ��¿� �� �а� �ѷ�����
                // ����


                // isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, Ground);     // ���� ��� �ִ��� Ȯ�� ���׷� oncollision ����ϱ�� ��

                //if (isGrounded)
                //{
                //    jumpCount = 0;  // ���� ������ ���� Ƚ�� �ʱ�ȭ
                //}
                //if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)  // �����̽� ������ ����  && ����ī��Ʈ�� �ƽ� ����ī��Ʈ���� ���ٸ� 
                //{
                //    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                //    animator.SetTrigger("Jump");

                //}      

                //if (Input.GetButtonDown("Jump") && jumpCount == 1)  // ���� ���� ��ư�� ������ ����ī��Ʈ�� 1�̸� �ѹ� �� ����
                //{
                //    rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
                //    animator.SetTrigger("DoubleJump");


                //}
                //jumpCount++;
                #endregion

                if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayLength))      // ����, ����ĳ��Ʈ���� ������ �ν��Ѵٸ�
                {

                    Vector3 slopenormal = hit.normal;
                    Vector3 slopemovement = Vector3.ProjectOnPlane(localMoveDirection, slopenormal).normalized;


                    transform.position += slopemovement * slideSpeed * Time.deltaTime;  // �������������

                    // ���鿡 ���� ȸ�� ó�� (�ɼ�)
                    // Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.up, slopeNormal);
                    // transform.rotation = slopeRotation;
                }
                else
                {
                    transform.position += localMoveDirection * moveSpeed * Time.deltaTime;  // ������ �ƴ϶�� �Ϲ� ����������
                }
            }
        }



    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))       // Ground �±׿� ������ 
        {
            jumpCount = 2;  // ���鿡 ������ ���� Ƚ�� �ʱ�ȭ
        }


        if (collision.gameObject.CompareTag("Slide"))        // Slide �±׿� ������
        {

            jumpCount = 2;

            transform.position += localMoveDirection * slideSpeed * Time.deltaTime;
            animator.SetBool("Slide", true);
        }



        if (collision.gameObject.CompareTag("Trap"))    // trap�� �ε�����
        {

            //animator.SetBool("TrapFall", true); //  �ִϸ��̼��� ����ϰ�

            //animator.SetBool("TrapGetup", true); //  �ִϸ��̼��� ����ϰ�

            //rb.isKinematic = true;   // rigidbody�� iskinetic�� Ȱ��ȭ�ϰ�  

            Debug.Log("����");

            // �˹� ���� ����
            Vector3 knockBackDirection = transform.position - collision.transform.position;
            knockBackDirection.y = 0f; // ���� �������δ� �˹����� �ʵ��� ����

            // �˹� �� �߰�
            rb.AddForce(knockBackDirection.normalized * pushForce, ForceMode.Impulse);

        }

    }
}