using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour // 투명 박스를 통해 특정구간 카메라 1, 2 전환
{

    public GameObject targetname;
    public GameObject cam1; // 백 뷰 카메라
    public GameObject cam2; // 트래킹 카메라

    public bool checkingSwap;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject)
        {
            cam1.SetActive(checkingSwap);
            cam2.SetActive(checkingSwap);
        }
    }

   
}
