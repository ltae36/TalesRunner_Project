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

    private int jumpCount = 2;
    public float pushForce = 12f;  // Ʈ���� �ε����� ������ �Ÿ�/��

    public float rayLength = 10f;

    private AudioSource audioSource;
    public AudioClip runSound;
    public AudioClip jumpSound;
    public AudioClip doubleJumpSound;
    public AudioClip slideSound;
    public AudioClip boostSound;
    public AudioClip hitSound;

    public ParticleSystem particleSystem;

    public GameObject boostEffectPrefab;
    public GameObject runEffectPrefab;

    bool isSlide;
    bool isGround; // �������� �ƴ��� üũ

    private bool isFreeze = false;

    Rigidbody rb;
    Animator animator;

    //Vector3 lastPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
        jumpCount = 2;
        isSlide = false;

        //lastPosition = transform.position;  // ĳ������ ������ ��ġ ����
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        if (movement.magnitude > 0.1f)
        {
            Vector3 localMoveDirection = transform.TransformDirection(movement);
            Quaternion targetRotation = Quaternion.LookRotation(localMoveDirection);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);




            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += localMoveDirection * runSpeed * Time.deltaTime;
                animator.SetFloat("Speed", runSpeed);

                if (!isSlide && gameObject.CompareTag("Ground"))  // �����̵� ���°� �ƴϰ� ���� �϶��� 
                {




                    GameObject runSmoke = Instantiate(runEffectPrefab, transform.position, Quaternion.identity);

                    ParticleSystem particleSystem = runSmoke.GetComponent<ParticleSystem>();

                    runSmoke.transform.SetParent(transform);

                    //GameObject runSmoke = Instantiate(runEffectPrefab, transform.position, Quaternion.identity);

                    // ParticleSystem particleSystem = runSmoke.GetComponent<ParticleSystem>(); // �÷��̾ particle system component�� �����ϱ� �ȴٸ� �̷��� ����



                    if (particleSystem != null)
                    {
                        particleSystem.Play();
                    }

                    if (audioSource != null)
                    {
                        PlayRunSound(); // ������ ���
                    }


                }
            }
            else
            {
                transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed);

                if (!isSlide && gameObject.CompareTag("Ground")) // �����̵� ���°� �ƴ� ���� �޸��� �Ҹ� ���
                {
                    GameObject runSmoke = Instantiate(runEffectPrefab, transform.position, Quaternion.identity);

                    ParticleSystem particleSystem = runSmoke.GetComponent<ParticleSystem>();

                    particleSystem.Play();

                    PlayRunSound();
                }
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }





        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount > 0)
            {
                if (jumpCount == 2)
                {
                    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                    animator.SetTrigger("Jump");

                    audioSource.clip = jumpSound;
                    audioSource.Play();
                    StopRunSound(); // ���� �� �޸��� �Ҹ� ����
                }
                else if (jumpCount == 1)
                {
                    rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
                    animator.SetTrigger("DoubleJump");

                    audioSource.clip = doubleJumpSound;
                    audioSource.Play();
                    StopRunSound(); // ���� ���� �� �޸��� �Ҹ� ����
                }
                jumpCount--;
            }
        }

        //if (Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.LeftShift) && IsCharacterMoving()) // ĳ���Ͱ� jump�� ������ shift�� ������ �����̴� ���̶��
        //{
        //    if (jumpCount > 0)
        //    {
        //        if (jumpCount == 2)
        //        {
        //            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //            animator.SetTrigger("Jump");

        //            StopRunSound(); // ���� �� �޸��� �Ҹ� ����
        //            audioSource.clip = jumpSound;
        //            audioSource.Play();

        //        }
        //        else if (jumpCount == 1)
        //        {
        //            rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
        //            animator.SetTrigger("DoubleJump");

        //            StopRunSound(); // ���� ���� �� �޸��� �Ҹ� ����
        //            audioSource.clip = doubleJumpSound;
        //            audioSource.Play();

        //        }
        //        jumpCount--;
        //    }
        //}







        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayLength))
        {
            Vector3 slopeNormal = hit.normal;
            Vector3 slopeMovement = Vector3.ProjectOnPlane(localMoveDirection, slopeNormal).normalized;
            transform.position += slopeMovement * slideSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += localMoveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 2;
            animator.SetBool("Slide", false);
            isSlide = false;
        }

        if (collision.gameObject.CompareTag("Slide"))
        {
            jumpCount = 2;
            animator.SetBool("Slide", true);

            isSlide = true;
            PlaySlideSound();
            //StopRunSound(); // �����̵� �� �޸��� �Ҹ� ����
        }

        if (collision.gameObject.CompareTag("Trap"))    //Trap�� ������� �ۿ�
        {

            //Vector3 pushDir = transform.position - collision.transform.position;
            Vector3 pushDir = new Vector3(0f, 3f, -2f);


            rb.AddForce(pushDir * pushForce, ForceMode.Impulse);

            PlayHitSound();    // hit ���� ���

            animator.SetTrigger("Hit");   // hit ��� ���

            StartCoroutine(FreezePlayer()); // ĳ���͸� �� �����̰��ϴ� �ڷ�ƾ ����
        }
    }

    IEnumerator FreezePlayer()
    {
        isFreeze = true;

        yield return new WaitForSeconds(3f);

        isFreeze = false;
    }



    void PlayRunSound()
    {
        if (!audioSource.isPlaying || audioSource.clip != runSound)
        {
            audioSource.clip = runSound;
            audioSource.Play();
        }
    }

    //bool IsCharacterMoving() // ĳ���Ͱ� �����̴� �ƴ��� üũ
    //{
    //    return transform.position != lastPosition;
    //}

    void StopRunSound()
    {
        if (audioSource.clip == runSound)
        {
            audioSource.Stop();
        }
    }

    void PlaySlideSound()
    {
        if (slideSound != null)
        {
            audioSource.clip = slideSound;
            audioSource.Play();
            StopRunSound();
        }
    }

    void PlayHitSound()
    {
        if (hitSound != null)
        {
            audioSource.clip = hitSound;
            audioSource.Play();
        }
    }

    void PlayBoostSound()
    {
        if (boostSound != null)
        {
            StopRunSound();
            audioSource.clip = boostSound;
            audioSource.Play();
        }
    }

    public IEnumerator DashBoost(float speedBoost, float speedDuration, float effectDuration)
    {
        Debug.Log("�ν��� ����");



        float originSpeed = runSpeed;

        runSpeed += speedBoost;


        GameObject boostEffect = Instantiate(boostEffectPrefab, transform.position, Quaternion.identity);
        boostEffect.transform.SetParent(transform);
        boostEffect.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        ParticleSystem particleSystem = boostEffect.GetComponent<ParticleSystem>();

        particleSystem.Play();


        PlayBoostSound();

        yield return new WaitForSeconds(speedDuration);

        runSpeed = originSpeed;        

        Destroy(boostEffect, effectDuration);
    }



    //    public IEnumerator Reduce(float speedBoost, float speedDuration)
    //    {
    //        Debug.Log("���ེ ����");

    //        float originSpeed = runSpeed;

    //        runSpeed -= speedBoost;

    //        yield return new WaitForSeconds(speedDuration);

    //        runSpeed = originSpeed;


    //    }
    //}
}