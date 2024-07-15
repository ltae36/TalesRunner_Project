using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // �� �Ŵ���

public class GameManager : MonoBehaviour
{



    GameManager gm;

    public GameObject trackUI;   // track ui
    public GameObject goleinUI;  // golein �� ������ ui




    public int timer;

    public Text timerText;
    private float startTime;

    public GameObject TrackUI;

    
    AudioSource audioSource;


    private void Awake() 
    {
    
        if (gm == null)     // ���� �� �� ���� �����ϵ��� ó��
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void Start()
    {
        
    }

    void Update()
    {
        bgmStart();

        restart();


        //if(Input.GetButtonDown("escape"))
        //{
        //    Application.Quit();
        //}

        quit();
    }

    void Timer()
    {
        
    }

    public void restart() // �ٽ��ϱ� ��ư || f12 ������ �ٽ��ϱ�
    {
        
        Input.GetKeyDown(KeyCode.F12);
    }

    public void quit() // �׸��ϱ� ��ư || esc ������ ������
    {        
        Application.Quit();

        // esc��?

    }

    public void bgmStart()
    {
        if(audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

}
