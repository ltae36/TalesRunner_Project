using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotTrigger : MonoBehaviour
{
    // ����Ʈ����Ʈ�� ���� ���¿��� �÷��̾ Ʈ���� ���� �ȿ� ������
    // �÷��̾�� �̵��Ҵ� ������ ������ ������� �ɷ� ���ۺ��۵��� �������� ���ϰ� �ȴ�.
    // ���� �ð��� �帣�� �ٽ� ������ �� �ְ� �ȴ�.
    public GameObject flash;
    public GameObject player;
    public float stopDuration = 5.0f; // �÷��̾ ���ߴ� �ð�

    float currentTime; // �÷��̾ �������� �Ǿ��ִ� �ð�
    bool canMove;
    Final playerMove;

    //Final playerMove = new Final();

    void Start()
    {
        canMove = true;
    }

    void Update()
    {        
       // canMove�� true��� �÷��̾�� �̵��� ������
       // canMove�� false��� �÷��̾�� �������� �Ǿ� moveSpeed�� 0�� ��.
    }


    private void OnTriggerEnter(Collider other)
    {
        if (flash.activeInHierarchy)
        {
            print("����Ʈ����Ʈ�� ��Ҵ�!");
            //playerMove = player.GetComponent<Final>();
            player.transform.position = transform.position;
        }
    }
}
