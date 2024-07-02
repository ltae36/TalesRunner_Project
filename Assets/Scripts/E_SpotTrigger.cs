using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotTrigger : MonoBehaviour
{    
    public GameObject go;

    public float stopDuration = 5.0f; // �÷��̾ ���ߴ� �ð�
    float currentTime;
    PlayerMove move = new PlayerMove();

    void Start()
    {
        move.canMove = true;
    }

    void Update()
    {
       if(move.canMove == false) 
        {
            currentTime += Time.deltaTime;
            print(currentTime);
            if(currentTime > stopDuration) 
            {
                go.GetComponent<PlayerMove>().canMove = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // ����Ʈ����Ʈ�� ������ ������ ���°� �Ǿ� ������ �� ���� �ȴ�.
        if(other.gameObject.tag == "Player") 
        {
            print("����Ʈ����Ʈ�� ��Ҵ�!");
            other.GetComponent<PlayerMove>().canMove = false;
            move.canMove = false;
        }
    }
}
