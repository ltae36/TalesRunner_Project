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


    private AudioSource audioSource;

    public AudioClip runSound;
    public AudioClip jumpSound;
    public AudioClip doubleJumpSound;
    public AudioClip hitSound;
    public AudioClip slideSound;
    public AudioClip boostSound;


    public GameObject boostEffectPrefab;


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
        // �̵� �Է� ó��
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;


        if (movement.magnitude > 0.1f)   // �̵� ���� ������ ���̰� ���� ������ ũ�� ȸ�� �� �̵��մϴ�
        {

            // ĳ������ ���� �������� �̵� ���� ����
            Vector3 localMoveDirection = transform.TransformDirection(movement);

            // �̵� �������� ȸ��
            if (movement.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }



            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += localMoveDirection * runSpeed * Time.deltaTime;
                animator.SetFloat("Speed", runSpeed); // �޸��� �ִϸ��̼� �Է�

                audioSource.clip = runSound;
                audioSource.Play();

            }
            else
            {
                transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed); // �ȱ� �ִϸ��̼� �Է�

                audioSource.clip = runSound;
                audioSource.Play();
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


        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Space) && (Input.GetKey(KeyCode.LeftShift)))) // isrun ���� �ϴ°� �� ��������
        {
            if (jumpCount == 2)
            {
                // ù ��° ����
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                animator.SetTrigger("Jump");
                animator.SetBool("Slide", false);

                audioSource.clip = jumpSound;
                audioSource.Play();

                jumpCount--;
            }
            else if (jumpCount == 1)
            {
                // �� ��° ���� (���� ����)
                rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);

                animator.SetTrigger("DoubleJump");
                animator.SetBool("Slide", false);

                audioSource.clip = doubleJumpSound;
                audioSource.Play();

                jumpCount--;
            }
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))       // Ground �±׿� ������ 
        {
            jumpCount = 2;  // ���鿡 ������ ���� Ƚ�� �ʱ�ȭ
            animator.SetBool("Slide", false);
        }


        if (collision.gameObject.CompareTag("Slide"))        // Slide �±׿� ������
        {

            jumpCount = 2;

            transform.position += localMoveDirection * slideSpeed * Time.deltaTime;
            animator.SetBool("Slide", true);

            audioSource.clip = slideSound;
            audioSource.Play();
        }




        if (collision.gameObject.CompareTag("Trap"))    // trap�� �ε�����
        {

            //Debug.Log("����");

            // �˹� ���� ����
            Vector3 knockBackDirection = transform.position - collision.transform.position;
            knockBackDirection.y = 0f; // ���� �������δ� �˹����� �ʵ��� ����

            // �˹� �� �߰�
            rb.AddForce(knockBackDirection.normalized * pushForce, ForceMode.Impulse);

        }

    }

    public IEnumerator DashBoost(float speedBoost, float speedDuration, float effectDuration)   // ��ù����� ������� 
    {
        Debug.Log("�ӵ�����");
        float originSpeed = runSpeed;

        // �̵� �ӵ� ����
        runSpeed += speedBoost;

        // ��ƼŬ �ý��� �߰� �� ���
        GameObject boostEffect = Instantiate(boostEffectPrefab, transform.position, Quaternion.identity);
        boostEffect.transform.SetParent(transform); // ĳ���Ϳ� �����ϰų� ĳ���� ��ġ�� ���� ��ġ

        ParticleSystem particleSystem = boostEffect.GetComponent<ParticleSystem>();
        particleSystem.Play();

        // ���� ���
        audioSource.clip = boostSound;
        audioSource.Play();

        yield return new WaitForSeconds(speedDuration);

        Debug.Log("�ӵ�����");
        runSpeed = originSpeed;

        audioSource.Stop();

        // ����Ʈ ����
        Destroy(boostEffect, effectDuration);
    }
}

