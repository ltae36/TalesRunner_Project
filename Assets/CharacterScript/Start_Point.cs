using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Point : MonoBehaviour
{
   public Game_Manager gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(gm.StartCount());
        }
    }
}
   