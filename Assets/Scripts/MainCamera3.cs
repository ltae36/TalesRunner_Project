using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera3 : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;
    //public Vector3 ang = new Vector3(0, -3, 0); 

    void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.position = player.transform.position + new Vector3(0, 10, -20);
        //this.gameObject.transform.rotation = ang;
    }
}
