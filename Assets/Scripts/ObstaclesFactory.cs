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
    float delayTime = 1.75f;
    float currentTime = 1.75f;

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
                barrelPrefab.transform.position = factory.transform.position;     
                currentTime = 0;
            }
            if (deathTime > 8) 
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
