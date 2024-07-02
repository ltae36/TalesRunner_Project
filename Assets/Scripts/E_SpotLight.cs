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
        // Ÿ�ֿ̹� ���� ����Ʈ����Ʈ�� ������ ������.
        startTime += Time.deltaTime;        
        if(startTime > lifeSpan)
        {
            flash.SetActive(true);
        }        
    }      
}
