using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 5f;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        



        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();


        transform.Translate(dir * speed * Time.deltaTime, Space.World);


        if (dir != Vector3.zero)
        {
            if(Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))
            {
                transform.Rotate(0, 1, 0);
            }
            transform.forward = Vector3.Lerp(transform.forward, dir, rotationSpeed * Time.deltaTime);


            //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, rotationSpeed * Time.deltaTime);
        }
        rigid.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }
}
