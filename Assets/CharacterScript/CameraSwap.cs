using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour // ���� �ڽ��� ���� Ư������ ī�޶� 1, 2 ��ȯ
{

    public GameObject targetname;
    public GameObject cam1; // �� �� ī�޶�
    public GameObject cam2; // Ʈ��ŷ ī�޶�

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
