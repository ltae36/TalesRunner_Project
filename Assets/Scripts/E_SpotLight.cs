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
            // Ÿ�ֿ̹� ���� ����Ʈ����Ʈ�� ������ ������.            
            if (startTime > lifeSpan)
            {
                flash[i].SetActive(true);          
                
            }       
            
        }      
        
        // �ð��� �帣�� �ڵ����� ������.
        for(int i = 0; i < flash.Length; i++) 
        {
            if (startTime > endTime)
            {
                flash[i].SetActive(false);
            }
        }        
    }      
}
