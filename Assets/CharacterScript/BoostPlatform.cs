using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    public float boost = 5f;  // �ν�Ʈ �߰��ӵ�
    public float boostTime = 3f;  //�ν�Ʈ �ð� 3��


    void Start()
    {
        
    }

    void Update()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Final playerMovement = other.GetComponent<Final>(); // Fianl�� playermovent ���� ����


            if(playerMovement != null)
            {
                Debug.Log("�÷��̾ ���ǿ� ��ҽ��ϴ�. �ӵ� �ν�Ʈ ����.");
                playerMovement.StartCoroutine(playerMovement.BoostSpeed(boost, boostTime));  // �� ������Ʈ�� "�÷��̾�" �±��� ���ӿ�����Ʈ�� ������ Final ��ũ��Ʈ�� �ӵ��߰��� ��û
            }                                                                  // BoostSpeed �Լ��� Final ��ũ��Ʈ�� �ִ�.


        }

    }
}
