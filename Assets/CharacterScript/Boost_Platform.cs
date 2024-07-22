using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Platform : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

        }
    }
}
