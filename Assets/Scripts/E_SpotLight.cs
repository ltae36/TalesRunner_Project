using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotLight : MonoBehaviour
{
    public GameObject flash;    
    float lifeSpan = 10.0f;
    public float startTime;
    
    private void Update()
    {
        flash.SetActive(false);
        // 타이밍에 맞춰 스포트라이트가 꺼졌다 켜진다.
        startTime += Time.deltaTime;        
        if(startTime > lifeSpan)
        {
            flash.SetActive(true);
        }        
    }      
}
