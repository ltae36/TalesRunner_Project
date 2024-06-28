using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera4 : MonoBehaviour
{

    public GameObject target;

    public float cameraX;
    public float cameraY;
    public float cameraZ;

    public float cameraRX;
    public float cameraRY;
    public float cameraRZ;


    public float DelayTime = 2;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 CameraPos = new Vector3(target.transform.position.x + cameraX, target.transform.position.y + cameraY, target.transform.position.z + cameraZ);

        transform.position = Vector3.Lerp(transform.position, CameraPos, Time.deltaTime);

        //Vector3 CameraRotate = new Vector3(cameraRX, cameraRY, cameraRZ);
        //transform.rotation = Vector3.Angle(transform.rotation, CameraRotate);
    }
}
