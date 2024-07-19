using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class FInalTEST : MonoBehaviour
{
    public float moveSpeed = 5f; // ĳ������ �̵� �ӵ�
    public float rotationSpeed = 150f; // ĳ������ ȸ�� �ӵ�
    Vector3 moveDirection;

    public float walkSpeed = 5f;
    public float runSpeed = 20f;
    public float slideSpeed = 30f;

    public float jumpHeight = 20f;
    public float doubleJumpHeight = 20f;  // �̴� ���� ��

    //public int maxJumpCount = 2;  // �ִ� ���� Ƚ��
    private int jumpCount = 2;



    //public float groundCheckDistance = 0.1f;  // �� ���� �Ÿ�
    //public LayerMask Ground;  // �׶��� ���̾�
    //public LayerMask Slide; // �����̵� ���̾�

    public float rayLength = 2f;



    public float pushForce = 40f; // trap�� �ε����� ���ĳ� ��

    //public Vector3 pushDirection = Vector3.back; // ���ĳ� ���� / ��
    public Vector3 pushDirection;// ���ĳ� ���� / ��



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

        float moveInput = Input.GetAxis("Vertical"); // W/S �Ǵ� ���� ����Ű �Է�
        float turnInput = Input.GetAxis("Horizontal"); // A/D �Ǵ� �¿� ����Ű �Է�

        // �̵� ���� ���
        Vector3 moveDirection = transform.forward * moveInput;

        // ���� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ���� ȸ�� ó��
        if (turnInput != 0)
        {
            // ȸ���� ���� ���� ���
            Vector3 turnDirection = new Vector3(0, turnInput, 0);

            // ��ǥ ȸ�� ���� ���
            Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + turnInput * rotationSpeed * Time.deltaTime, 0);

            // ��� ȸ��
            transform.rotation = targetRotation;
        }





            if (moveDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed = runSpeed;

                    transform.position += moveDirection * moveSpeed * Time.deltaTime;
                    animator.SetFloat("Speed", runSpeed); // �޸��� �ִϸ��̼� �Է�

                    audioSource.clip = soundRun;
                    audioSource.Play();


                }
                else
                {
                    moveSpeed = walkSpeed;

                    transform.position += moveDirection * moveSpeed * Time.deltaTime;
                    animator.SetFloat("Speed", walkSpeed); // �ȱ� �ִϸ��̼� �Է�
                }
            }
            else
            {
                // �÷��̾ ���� ���� ��
                animator.SetFloat("Speed", 0f); // "Speed" �Ķ���͸� 0���� �����Ͽ� Idle ���·� ��ȯ  
            }



            // ����ĳ��Ʈ�� ����� Slide�±� ���� �̵�/�����̵� �ڿ�������


            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit Hit, rayLength))      // ����, ����ĳ��Ʈ���� ������ �ν��Ѵٸ�
            {

                Vector3 slopeNormal = Hit.normal;

                if (Hit.collider.CompareTag("Slide"))
                {
                    Vector3 slopeDirection = Vector3.ProjectOnPlane(moveDirection, slopeNormal).normalized;

                    transform.position += slopeDirection * slideSpeed * Time.deltaTime;  // ���� �ӵ���

                    //Quaternion slopeRotation = Quarternion.FromtoRotation(Vector3.up )

                }
                else
                {
                    transform.position += moveDirection * moveSpeed * Time.deltaTime;  // ������ �ƴ϶�� �Ϲ� �ӵ���
                }
            }










            if (Input.GetKeyDown(KeyCode.Space))  // ����
            {
                if (jumpCount == 2)
                {
                    // ù ��° ����
                    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                    animator.SetTrigger("Jump");    // ���� �ִϸ��̼� ����
                    animator.SetBool("Slide", false);  // �����̵�� ��� x


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

                }

                //if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))    // ��ô����� ���·� + ���� �Ҷ��� �Ҹ� ����ؾ� �� 
                //{
                //    if (jumpCount == 2)
                //    {
                //        // ù ��° ����
                //        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                //        animator.SetTrigger("Jump");
                //        animator.SetBool("Slide", false);
                //        audioSource.clip = soundJump;
                //        audioSource.Play();
                //        jumpCount--;
                //    }
                //    else if (jumpCount == 1)
                //    {
                //        // �� ��° ���� (���� ����)
                //        rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);

                //        animator.SetTrigger("DoubleJump");
                //        animator.SetBool("Slide", false);
                //        audioSource.clip = soundDoubleJump;
                //        audioSource.Play();
                //        jumpCount--;

                //    }
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


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))  // trap �±��� ������Ʈ�� ���
        {
            if (rb != null)   // ������ �ٵ� null���� �ƴ϶��
            {
                pushDirection = new Vector3(0f, 5f, -5f); // ���ĳ� ���� ����

                //animator.SetTrigger

                rb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);  // ���ĳ���

            }
        }
    }





    public IEnumerator BoostSpeed(float boost, float boostTime)
    {
        float originalSpeed = moveSpeed; // �������� ���ǵ忡 ���� �̵��ӵ��� �ִ´�

        moveSpeed += boost; // �̵� �ӵ��� ���� �ν�Ʈ �ӵ��� ���Ѵ�.
        Debug.Log("Speed increased to {moveSpeed}.");



        yield return new WaitForSeconds(boostTime);  // �ν�Ʈ �ð��� ������ �����ϰ� ��ٸ���.

        Debug.Log("�����ӵ��� ���ư��ϴ� �ӵ� �ν�Ʈ ��.");
        moveSpeed = originalSpeed;  // �����ӵ��� �ٽ� �������´�

    }

}

