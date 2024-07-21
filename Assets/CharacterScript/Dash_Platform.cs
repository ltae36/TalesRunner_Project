using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Platform : MonoBehaviour  // 대시발판
{

    public float boostSpeed = 10f;
    public float boostTime = 3f;
    public float effectTime = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Final playermove = other.GetComponent<Final>();

            if(playermove != null)
            {
                playermove.StartCoroutine(playermove.DashBoost(boostSpeed, boostTime, effectTime));

               

            }
           
        }
    }

  
}
