using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesFactory : MonoBehaviour
{
    public GameObject oakBarrel;
    public GameObject factory;
    public bool playerAccess = false;
    
    
    float deathTime = 0;
    float delayTime = 1.85f;
    float currentTime = 1.85f;
    

    void Start()
    {
        
    }

    private void Update()
    {        
        if (playerAccess)
        {
            print(currentTime);
            currentTime += Time.deltaTime;
            deathTime += Time.deltaTime;
            if (currentTime > delayTime)
            {
                Instantiate(oakBarrel);
                currentTime = 0;
                oakBarrel.transform.position = factory.transform.position;              
            }
            if (deathTime >= 4) 
            {
                Destroy(oakBarrel);
                factory.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerAccess = true;
        }
    }
}
