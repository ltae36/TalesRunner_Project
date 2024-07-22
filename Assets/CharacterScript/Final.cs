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

    private int jumpCount = 2;
    public float pushForce = 12f;  // 트랩에 부딪히면 밀쳐질 거리/힘

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
    bool isGround; // 땅위인지 아닌지 체크

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

        //lastPosition = transform.position;  // 캐릭터의 마지막 위치 저장
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

                if (!isSlide && gameObject.CompareTag("Ground"))  // 슬라이드 상태가 아니고 땅위 일때만 
                {




                    GameObject runSmoke = Instantiate(runEffectPrefab, transform.position, Quaternion.identity);

                    ParticleSystem particleSystem = runSmoke.GetComponent<ParticleSystem>();

                    runSmoke.transform.SetParent(transform);

                    //GameObject runSmoke = Instantiate(runEffectPrefab, transform.position, Quaternion.identity);

                    // ParticleSystem particleSystem = runSmoke.GetComponent<ParticleSystem>(); // 플레이어에 particle system component를 부착하기 싫다면 이렇게 선언



                    if (particleSystem != null)
                    {
                        particleSystem.Play();
                    }

                    if (audioSource != null)
                    {
                        PlayRunSound(); // 런사운드 출력
                    }


                }
            }
            else
            {
                transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed);

                if (!isSlide && gameObject.CompareTag("Ground")) // 슬라이드 상태가 아닐 때만 달리기 소리 재생
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
                    StopRunSound(); // 점프 시 달리기 소리 중지
                }
                else if (jumpCount == 1)
                {
                    rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
                    animator.SetTrigger("DoubleJump");

                    audioSource.clip = doubleJumpSound;
                    audioSource.Play();
                    StopRunSound(); // 이중 점프 시 달리기 소리 중지
                }
                jumpCount--;
            }
        }

        //if (Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.LeftShift) && IsCharacterMoving()) // 캐릭터가 jump를 누르고 shift를 누르고 움직이는 중이라면
        //{
        //    if (jumpCount > 0)
        //    {
        //        if (jumpCount == 2)
        //        {
        //            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //            animator.SetTrigger("Jump");

        //            StopRunSound(); // 점프 시 달리기 소리 중지
        //            audioSource.clip = jumpSound;
        //            audioSource.Play();

        //        }
        //        else if (jumpCount == 1)
        //        {
        //            rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
        //            animator.SetTrigger("DoubleJump");

        //            StopRunSound(); // 이중 점프 시 달리기 소리 중지
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
            //StopRunSound(); // 슬라이드 시 달리기 소리 중지
        }

        if (collision.gameObject.CompareTag("Trap"))    //Trap에 닿았을때 작용
        {

            //Vector3 pushDir = transform.position - collision.transform.position;
            Vector3 pushDir = new Vector3(0f, 3f, -2f);


            rb.AddForce(pushDir * pushForce, ForceMode.Impulse);

            PlayHitSound();    // hit 사운드 출력

            animator.SetTrigger("Hit");   // hit 모션 출력

            StartCoroutine(FreezePlayer()); // 캐릭터를 못 움직이게하는 코루틴 시작
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

    //bool IsCharacterMoving() // 캐릭터가 움직이는 아닌지 체크
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
        Debug.Log("부스터 시작");



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
    //        Debug.Log("리듀스 시작");

    //        float originSpeed = runSpeed;

    //        runSpeed -= speedBoost;

    //        yield return new WaitForSeconds(speedDuration);

    //        runSpeed = originSpeed;


    //    }
    //}
}