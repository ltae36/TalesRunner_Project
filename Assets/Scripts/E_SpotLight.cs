using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotLight : MonoBehaviour
{
    public GameObject[] flash;
    public float lifeSpan = 4.0f;
    public float startTime;
    public float endTime = 8.0f;

    CurtainOpen open = new CurtainOpen();
    
    private void Update()
    {
        
        startTime += Time.deltaTime;
        for (int i = 0; i < flash.Length; i++)
        {            
            flash[i].SetActive(false);
            // 타이밍에 맞춰 스포트라이트가 꺼졌다 켜진다.            
            if (startTime > lifeSpan)
            {
                flash[i].SetActive(true);          
                
            }       
            
        }      
        
        // 시간이 흐르면 자동으로 꺼진다.
        for(int i = 0; i < flash.Length; i++) 
        {
            if (startTime > endTime)
            {
                flash[i].SetActive(false);
            }
        }        
    }      
}
