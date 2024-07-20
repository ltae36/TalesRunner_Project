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
    public float rotationSpeed = 100f; // ĳ������ ȸ�� �ӵ�
    Vector3 moveDirection;

    public float walkSpeed = 5f;
    public float runSpeed = 20f;
    public float slideSpeed = 30f;

    public float jumpHeight = 20f;
    public float doubleJumpHeight = 20f;  // �̴� ���� ��

    //public int maxJumpCount = 2;  // �ִ� ���� Ƚ��
    private int jumpCount = 2;
    public float pushForce = 10f;  // Ʈ���� �ε����� ������ �Ÿ�/��


    //public float groundCheckDistance = 0.1f;  // �� ���� �Ÿ�
    //public LayerMask Ground;  // �׶��� ���̾�
    //public LayerMask Slide; // �����̵� ���̾�

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
        //ĳ���� �̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;



        if (moveDirection != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += moveDirection * runSpeed * Time.deltaTime;
                animator.SetFloat("Speed", runSpeed); // �޸��� �ִϸ��̼� �Է�

                audioSource.clip = soundRun;
                audioSource.Play();


            }
            else
            {
                transform.position += moveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed); // �ȱ� �ִϸ��̼� �Է�
            }
        }
        else
        {
            // �÷��̾ ���� ���� ��
            animator.SetFloat("Speed", 0f); // "Speed" �Ķ���͸� 0���� �����Ͽ� Idle ���·� ��ȯ  
        }



        // ĳ���� ȸ��

        Vector3 lookDirection = new Vector3(horizontalInput, 0f, verticalInput);    // ĳ���Ͱ� ���¹��� = ȸ������ 

        if (lookDirection != Vector3.zero) // ���� ���� ������ 0���� �ƴ϶��
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);    // ��ǥ �������� ȸ�� , ȸ������ �Լ�

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);   // �ε巴�� ȸ���Ҷ� Slerp ���
        }






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
                    Vector3 slopemovement = Vector3.ProjectOnPlane(moveDirection, slopenormal).normalized;


                    transform.position += slopemovement;  // �������������

                    //quaternion sloperotation = quarternion.fromtorotation(vector3.up )
                }
                else
                {
                    transform.position += moveDirection * moveSpeed * Time.deltaTime;  // ������ �ƴ϶�� �Ϲ� ����������
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

            transform.position += moveDirection * slideSpeed * Time.deltaTime;
            animator.SetBool("Slide", true);
        }



        if (collision.gameObject.CompareTag("Trap"))    // trap�� �ε�����
        {

            //animator.SetBool("TrapFall", true); //  �ִϸ��̼��� ����ϰ�

            //animator.SetBool("TrapGetup", true); //  �ִϸ��̼��� ����ϰ�

            //rb.isKinematic = true;   // rigidbody�� iskinetic�� Ȱ��ȭ�ϰ�  



            

            Debug.Log("����");
            //Vector3 knockBack = new Vector3(0, 1f, 1f).normalized;
            Vector3 knockBack = (transform.position - collision.transform.position).normalized;   //  �˹��ų ������ �����ϰ�


            rb.AddForce(knockBack * pushForce, ForceMode.Impulse);   //  �˹��ų ���� �߰��Ѵ�.

        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Trap")) // ���� �浹�� ���
    //    {
    //        Vector3 knockBack = (transform.position - other.transform.position).normalized;
    //        rb.AddForce(knockBack * pushForce, ForceMode.Impulse);
    //    }
    //}
}