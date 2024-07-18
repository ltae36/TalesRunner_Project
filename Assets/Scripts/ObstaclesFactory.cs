using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesFactory : MonoBehaviour
{
    public GameObject barrelPrefab;
    public GameObject factory;
    public bool playerAccess = false;
        
    public float deathTime = 0;
    float delayTime = 1.85f;
    float currentTime = 1.85f;

    void Start()
    {
        
    }

    private void Update()
    {        
        if (playerAccess)
        {
            currentTime += Time.deltaTime;
            deathTime += Time.deltaTime;
            if (currentTime > delayTime)
            {
                Instantiate(barrelPrefab);
                currentTime = 0;
                barrelPrefab.transform.position = factory.transform.position;              
            }
            if (deathTime > 4) 
            {
                playerAccess = false;
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
