using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // 씬 매니저

public class GameManager : MonoBehaviour
{



    GameManager gm;

    public GameObject trackUI;   // track ui
    public GameObject goleinUI;  // golein 시 나오는 ui




    public int timer;

    public Text timerText;
    private float startTime;

    public GameObject TrackUI;

    
    AudioSource audioSource;


    private void Awake() 
    {
    
        if (gm == null)     // 씬에 단 한 개만 존재하도록 처리
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

    public void restart() // 다시하기 버튼 || f12 누르면 다시하기
    {
        
        Input.GetKeyDown(KeyCode.F12);
    }

    public void quit() // 그만하기 버튼 || esc 누르면 끝내기
    {        
        Application.Quit();

        // esc는?

    }

    public void bgmStart()
    {
        if(audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

}
