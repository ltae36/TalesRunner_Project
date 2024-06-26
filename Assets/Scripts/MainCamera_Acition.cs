using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Acition : MonoBehaviour // 플레이어 트래킹 카메라
{

    //Vector3 TargetPos;
    //Vector3 CameraPos;

    //public float CameraX = 10f;
    //public float CameraY = 10f;
    //public float CameraZ = 10f;


    public GameObject Target;

    Vector3 TargetPos;

    Vector3 CamerPos;
    //Vector3 CameraPos = new Vector3(0, 2, 3);
    //Vector3 CameraAng = new Vector3(0, -1, 0);
    public float cameraSpeed = 10f;






    void Start()
    {

    }

    void Update()
    {
        //transform.LookAt(Target);
    }

    private void FixedUpdate() // 움직이는 , 물리 오브젝트를 fixed에 배치하는 이유는 프레임 영향을 덜 받기 때문
    {
        //Vector3 TargetPos = new Vector3(Target.transform.position.x + CameraX,
        //    Target.transform.position.y + CameraY,
        //    Target.transform.position.z + CameraZ);
        //타켓의 x, y, z 값과 카메라의 x y z값을 더하여 위치결정

        
        TargetPos.Normalize();

        Vector3 CameraPos = Target.transform.position + new Vector3(0, 1.5f, -3);

        transform.position += TargetPos * cameraSpeed * Time.deltaTime; // p = p0 + vt






        //    //Target.transform.position + new Vector3(1, 1, 1)
        //}
    }
}
