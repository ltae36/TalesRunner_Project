using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBeach : MonoBehaviour
{
    public GameObject[] children;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].SetActive(true);
            }
        }
    }
}
