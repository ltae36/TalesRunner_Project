using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpotTrigger : MonoBehaviour
{    
    public GameObject go;
    public GameObject flash;

    public float stopDuration = 5.0f; // �÷��̾ ���ߴ� �ð�
    float currentTime;
    PlayerCrashed move = new PlayerCrashed();

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
                go.GetComponent<PlayerCrashed>().canMove = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (flash.activeInHierarchy)
        {
            // ����Ʈ����Ʈ�� ������ ������ ���°� �Ǿ� ������ �� ���� �ȴ�.
            if (other.gameObject.tag == "Player")
            {
                print("����Ʈ����Ʈ�� ��Ҵ�!");
                other.GetComponent<PlayerCrashed>().canMove = false;
                move.canMove = false;
            }
        }
    }
}
