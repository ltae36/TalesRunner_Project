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

    private AudioSource audiosource;

    public Text countdownText;
    public float StartTime;
    public Text timer_text;
    bool isTime;


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

        
        


    }




    void Update()
    {
       
        UpdateTime();
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



    public void UpdateTime()
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

   
    public void ResetTimer()
    {
        StartTime = Time.time;
    }
    

}



