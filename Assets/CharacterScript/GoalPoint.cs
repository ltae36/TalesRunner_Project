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
        if(other.gameObject.name.Contains("Player"))         
        {
            if (gm != null)
            {
                Debug.Log("¥Í¿Ω");
               // GameManager.gm.Goalin().SetActive(true);
            }

        }
    }


}
