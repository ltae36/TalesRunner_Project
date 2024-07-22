using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class Game_Manager : MonoBehaviour
{
    public static Game_Manager gm; // 다른 스크립트에서 game manager  에 접근가능

    public AudioSource audiosource;

    public Text countdownText;
    public float StartTime;
    public Text timer_text;
    
    bool isTime;

    public GameObject GoleinPanel;
    public Text goleinTimer_text;

    public Sprite[] starImage; // 별 이미지
    public UnityEngine.UI.Image starImageDisplay;





    private void Awake() // 싱글톤 선언
    {
        if (gm == null)
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
        audiosource = GetComponent<AudioSource>();

        BackgroundMusicStart();

        GoleinPanel.SetActive(false);

        starImage = new Sprite[4]; // sprite 형식의 배열 4칸을 선언

        starImage[0] = Resources.Load<Sprite>("Sprite/star0");    // Asset-Resources-Sprite-star0.image 파일
        starImage[1] = Resources.Load<Sprite>("Sprite/star1");
        starImage[2] = Resources.Load<Sprite>("Sprite/star2");
        starImage[3] = Resources.Load<Sprite>("Sprite/star3");

           


    }
    void Update()
    {

        DisplayTime();

       
    }

    public void GameRestart()  // 다시하기 
    {
        SceneManager.LoadScene("RacingTrack");
    }

    public void GameQuit()
    {
        Application.Quit();
    }



    public void BackgroundMusicStart()
    {
        if (audiosource != null)
        {
            Debug.Log("Audio playing: " + audiosource.isPlaying);

            audiosource.Play();
        }
    }



    public IEnumerator StartCount()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        StartTimer();

        countdownText.text = "";
    }

    public void StartTimer()
    {
        StartTime = Time.time;
        isTime = true;
       

    }

    public void StopTimer()
    {
        isTime = false;
    }



    public void DisplayTime()  // 타이머 표시
    {
        if (isTime)
        {
            float t = Time.time - StartTime;

            int min = (int)(t / 60);
            float sec = t % 60;
            int millisec = (int)((t * 1000) % 1000);

            timer_text.text = string.Format("{0:D2}:{1:D2}:{2:D3}", min, (int)sec, millisec);
        }
    }



    public void DisplayGoleinTime() // 골인 타임 표시
    {
        float t = Time.time - StartTime;  // Time.time은 초단위로 시간을 잰다.

        int min = (int)(t / 60);  
        float sec = t % 60;
        int millisec = (int)((t * 1000) % 1000);

        goleinTimer_text.text = string.Format("{0:D2}:{1:D2}:{2:D3}", min, (int)sec, millisec);

        if(t < 60f) // 60초 보다 적을경우
        {
            starImageDisplay.sprite = starImage[3];  // 별 3개 이미지
        }
        else if(t < 80f)
        {
            starImageDisplay.sprite = starImage[2]; // starImageDisplay 는 Image, 배열 선언은 sprite 이럴땐 그냥 뒤에 .sprite 로 선언해버리면 된다.
        }
        else if(t < 100f)
        {
            starImageDisplay.sprite = starImage[1];
        }
        else
        {
            starImageDisplay.sprite = starImage[0]; 
        }


    }

   
    public void ResetTimer()
    {
        StartTime = Time.time;
    }
    

}



