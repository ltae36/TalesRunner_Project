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
    public float pushForce = 20f;  // Ʈ���� �ε����� ������ �Ÿ�/��

    public float rayLength = 10f;

    private AudioSource audioSource;
    public AudioClip runSound;
    public AudioClip jumpSound;
    public AudioClip doubleJumpSound;
    public AudioClip slideSound;
    public AudioClip boostSound;
    public AudioClip hitSound;

    public GameObject boostEffectPrefab;

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
                if (!isSlide) // �����̵� ���°� �ƴ� ���� �޸��� �Ҹ� ���
                {
                    PlayRunSound();
                }
            }
            else
            {
                transform.position += localMoveDirection * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", walkSpeed);
                if (!isSlide) // �����̵� ���°� �ƴ� ���� �޸��� �Ҹ� ���
                {
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
            StopRunSound(); // �����̵� �� �޸��� �Ҹ� ����
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            Vector3 knockBackDirection = transform.position - collision.transform.position;
            knockBackDirection.y = 0f;
            rb.AddForce(knockBackDirection.normalized * pushForce, ForceMode.Impulse);
            PlayHitSound();
        }
    }

    void PlayRunSound()
    {
        if (!audioSource.isPlaying || audioSource.clip != runSound)
        {
            audioSource.clip = runSound;
            audioSource.Play();
        }
    }

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

        ParticleSystem particleSystem = boostEffect.GetComponent<ParticleSystem>();
        particleSystem.Play();

        PlayBoostSound();

        yield return new WaitForSeconds(speedDuration);

        runSpeed = originSpeed;
        audioSource.Stop();

        Destroy(boostEffect, effectDuration);
    }
}