using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Acition2 : MonoBehaviour
{
    public GameObject trackingCamera;
    public Vector3 cameraAng;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //cameraAng = Vector3.zero;

        Vector3 tracker = transform.position + new Vector3(0, 1.5f, 0);
        //Vector3 cameraAng = transform.rotation + new Vector3(0, -3, 0);
        
    }
}
