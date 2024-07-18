using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainOpen : MonoBehaviour
{
    public GameObject curtainL;
    public GameObject curtainR;

    public Transform openL;
    public Transform openR;

    public float moveSpeed = 2.0f;

    public GameObject flash;

    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            // �÷��̾ Ʈ���� ���� �ȿ� ������ 
            //Ŀư�� �¿�� ������.
            curtainR.transform.localScale = Vector3.Lerp(curtainR.transform.localScale, openR.localScale, Time.deltaTime * moveSpeed);
            curtainL.transform.localScale = Vector3.Lerp(curtainL.transform.localScale, openL.localScale, Time.deltaTime * moveSpeed);
            //����Ʈ����Ʈ�� Ȱ��ȭ�ȴ�
            flash.SetActive(true);
        }
    }
}
