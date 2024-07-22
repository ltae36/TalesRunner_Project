using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golein_Point : MonoBehaviour
{

    AudioSource finish;
    void Start()
    {
        finish = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)    // �÷��̾ ���� ������ ������ Ÿ�̸Ӹ� ���߰� �ð��� ǥ��
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Game_Manager.gm.GoleinPanel.SetActive(true);

            Game_Manager.gm.StopTimer();


            // float currentTime = Time.time - Game_Manager.gm.StartTime;  
            Game_Manager.gm.DisplayGoleinTime();    // Ŭ���� Ÿ��

            if (finish != null)
            { 
            finish.Play();
            }

            if (Game_Manager.gm.audiosource != null)  // �Ҹ��� 0.3 ���� ���߱�
            {
                Game_Manager.gm.audiosource.volume = 0.3f;
            }
        }
    }
}
