using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // 씬 매니저

public class GameManager : MonoBehaviour
{



    static public GameManager gm;

    public GameObject trackUI;   // track ui
    public GameObject goleinUI;  // golein 시 나오는 ui
                                 // 
    public Text timer;  // 실시간 타이머 text를 넣을칸
    float timeLapes = 0f; // 경과시간
    bool istimerRunning = false; // 타이머 실행중인지 아닌지



    public Text countDown; // 321 start 를 넣을 타이머 변수
    public Coroutine countDownCoroutine; // 321 start 코루틴

    



    private float startTime;
       

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
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
     

        if (timer == null)  // 만약 타이머가 비었다면
        {
            Debug.LogError("타이머 고장남");

        }
        else
        {
            ResetTimer(); // 게임 start 시 타이머리셋
            StartTimer(); // 타이머 스타트
        }

        


    }

    void Update()
    {
        bgmStart();

        if (istimerRunning) // 타이머가 꺼져있다면
        {
            timeLapes += Time.deltaTime; // 경과시간에 실시간 시간 누적
            UpdateTimeText(); // 타이머 텍스트 업데이트
        }
        
        

    }


    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(timeLapes / 60);
        int seconds = Mathf.FloorToInt((timeLapes % 60));
        int milliseconds = Mathf.FloorToInt((timeLapes % 1) * 1000);

        timer.text = string.Format("{0:D2}:{1:D2}:{2:D3}", minutes, seconds, milliseconds);
    }


    void StartTimer()

    {
        istimerRunning = true; // 타이머가 켜져있다.
    }

    void ResetTimer()
    {
        istimerRunning = false; // 타이머가 꺼져있다
    }

   

    public IEnumerator CountDown() // 플레이어가 start point 에 닿으면 카운트 3.2.1.Start를 출력하는 ui 
    {
        countDown.text = "3";

        yield return new WaitForSeconds(1);

        countDown.text = "2";

        yield return new WaitForSeconds(1);

        countDown.text = "1";

        yield return new WaitForSeconds(1);

        countDown.text = "START!";

        yield return new WaitForSeconds(1);

        countDown.text = "";

        Debug.Log("코루틴 종료");
        yield break;

    }

    public void GoalIn() // goleinUI에 넣음
    {

    }
    









    public void Restart() // 다시하기 버튼에 할당
    {
        
        Input.GetKeyDown(KeyCode.F12);
    }

    public void Quit() // 그만하기 버튼에 할당
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
