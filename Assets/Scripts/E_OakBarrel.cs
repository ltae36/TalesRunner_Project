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
        // Z������ ���������´�
        // �̵� ���� : p = p0 +vt

        transform.position += new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
    }
}
