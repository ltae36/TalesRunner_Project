using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    private Rigidbody rigid;
    public float Speed = 10f;
    public float jumpheight = 3f;
    public float dash = 5f;
    public float rotateSpeed = 10f;

    float h;
    float v;


    Vector3 move = Vector3.zero; // move 벡터에 vector3 (0,0,0) 을 담겟다

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
        move.Normalize();

    }
    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += move * Speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * rotateSpeed);
        }
    






        //if(move != Vector3.zero)
        //{
        //     지금 바라보는 방향의 부호 != 나아갈 방향 부호
        //    transform.forward = Vector3.Lerp(transform.forward, move, rotatespeed * Time.deltaTime);
        //}
        //rigid.MovePosition(gameObject.transform.position + move * speed * Time.deltaTime);





    }




    }

