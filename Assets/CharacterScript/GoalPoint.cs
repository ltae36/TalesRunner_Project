using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    GameManager gm;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))        // 
        {
            if (gm != null)
            {
              // golepoint ¿¡ ´êÀ¸¸é gole in UI¸¦ ¶ç¿î´Ù
            }

        }
    }


}
