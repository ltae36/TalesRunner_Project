
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerDoubleJump3 : MonoBehaviour
{

    Rigidbody pRigidbody;

    public float jumpForce = 3.0f;

    bool grounded = false;


    public int jumpPossible; //점프 수 지정가능
    int jumpCount; //점프 수 카운트

    void Start()
    {
        pRigidbody = GetComponent<Rigidbody>();
        jumpCount = jumpPossible;
    }
    void Update() // 무브먼트 업데이트 
    {
        Jump();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            // Sqrt 는 빠른 속도로 점프 하고 천천히 낙하하는 부자연스러움을 줄여줍니다.
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpForce * -Physics.gravity.y);

            pRigidbody.AddForce(jumpVelocity, ForceMode.Impulse);

            jumpCount--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != null)
        {
            grounded = true;
            jumpCount = jumpPossible;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag != null)
        {
            grounded = false;
        }
    }
    
}
