using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObstarcles : MonoBehaviour
{
    public GameObject[] objs;

    void Start()
    {
        foreach (GameObject obj in objs)
        {
            if(obj.activeInHierarchy == true) 
            {
                obj.SetActive(false);
            }            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            for(int i = 0; i < objs.Length; i++) 
            {
                objs[i].SetActive(true);
            }
        }
    }
}
