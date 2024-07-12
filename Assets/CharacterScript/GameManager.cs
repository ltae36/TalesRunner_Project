using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    GameManager gm;

    public int timer;

    public Text timerText;
    private float startTime;

    public GameObject TrackUI;






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
        
    }

    void Timer()
    {
        
    }

    void restart() // 다시하기 버튼 || f12 누르면 다시하기
    {
        TrackUI.SetActive(true);
        Input.GetKeyDown(KeyCode.F12);
    }

    public void quit() // 그만하기 버튼 || esc 누르면 끝내기
    {
        Application.Quit();

        // esc는?

    }

}
