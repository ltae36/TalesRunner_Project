using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotLight : MonoBehaviour
{
    public GameObject[] flash = new GameObject[5];    
    public float lifeSpan = 4.0f;
    public float startTime;
    float endTime = 8.0f;
    
    private void Update()
    {        
        startTime += Time.deltaTime;
        print(startTime);
        for (int i = 0; i < 5; i++)
        {            
            flash[i].SetActive(false);
            // 타이밍에 맞춰 스포트라이트가 꺼졌다 켜진다.            
            if (startTime > lifeSpan)
            {
                flash[i].SetActive(true);            
                
            }          
            
        }      
        
        for(int i = 0; i < 5; i++) 
        {
            if (startTime > endTime)
            {
                flash[i].SetActive(false);
            }
        }
        
    }      
}
