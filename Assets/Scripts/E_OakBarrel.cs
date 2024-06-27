using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_OakBarrel : MonoBehaviour
{
    public float moveSpeed = 10;
    public float lifeSpan = 5.0f;
    float currentTime;

    void Start()
    {
        
    }

    void Update()
    {
        // Z축으로 굴러내려온다
        // 이동 공식 : p = p0 +vt

        transform.position += new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
    }
}
