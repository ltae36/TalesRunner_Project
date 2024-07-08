using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainOpen : MonoBehaviour
{
    public GameObject curtainL;
    public GameObject curtainR;

    public Transform closePosL;
    public Transform closePosR;

    public float moveSpeed = 2.0f;

    public GameObject flash;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            // �÷��̾ Ʈ���� ���� �ȿ� ������ 
            //Ŀư�� �¿�� ������.
            curtainR.transform.position = Vector3.Lerp(curtainR.transform.position, closePosR.position, Time.deltaTime);
            curtainL.transform.position = Vector3.Lerp(curtainL.transform.position, closePosL.position, Time.deltaTime);
            //����Ʈ����Ʈ�� Ȱ��ȭ�ȴ�
            flash.SetActive(true);
        }
    }
}
