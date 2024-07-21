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

    private void OnTriggerEnter(Collider other)    // 플레이어가 골인 지점에 닿으면 타이머를 멈추고 시간을 표시
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Game_Manager.gm.GoleinPanel.SetActive(true);

            Game_Manager.gm.StopTimer();


            // float currentTime = Time.time - Game_Manager.gm.StartTime;  
            Game_Manager.gm.DisplayGoleinTime();    // 클리어 타임

            if (finish != null)
            { 
            finish.Play();
            }

            if (Game_Manager.gm.audiosource != null)  // 소리를 0.3 으로 낮추기
            {
                Game_Manager.gm.audiosource.volume = 0.3f;
            }
        }
    }
}
