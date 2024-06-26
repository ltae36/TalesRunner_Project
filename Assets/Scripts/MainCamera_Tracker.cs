using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Tracker : MonoBehaviour
{
    public GameObject tracker;
    


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 tracker = transform.position + new Vector3(0, 1.5f, 0);

    }
}
