using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class Game_Manager : MonoBehaviour
{
    public static Game_Manager gm; // �ٸ� ��ũ��Ʈ���� game manager  �� ���ٰ���

    public AudioSource audiosource;

    public Text countdownText;
    public float StartTime;
    public Text timer_text;
    
    bool isTime;

    public GameObject GoleinPanel;
    public Text goleinTimer_text;

    public Sprite[] starImage; // �� �̹���
    public UnityEngine.UI.Image starImageDisplay;





    private void Awake() // �̱��� ����
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

        starImage = new Sprite[4]; // sprite ������ �迭 4ĭ�� ����

        starImage[0] = Resources.Load<Sprite>("Sprite/star0");    // Asset-Resources-Sprite-star0.image ����
        starImage[1] = Resources.Load<Sprite>("Sprite/star1");
        starImage[2] = Resources.Load<Sprite>("Sprite/star2");
        starImage[3] = Resources.Load<Sprite>("Sprite/star3");

           


    }
    void Update()
    {

        DisplayTime();

       
    }

    public void GameRestart()  // �ٽ��ϱ� 
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



    public void DisplayTime()  // Ÿ�̸� ǥ��
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



    public void DisplayGoleinTime() // ���� Ÿ�� ǥ��
    {
        float t = Time.time - StartTime;  // Time.time�� �ʴ����� �ð��� ���.

        int min = (int)(t / 60);  
        float sec = t % 60;
        int millisec = (int)((t * 1000) % 1000);

        goleinTimer_text.text = string.Format("{0:D2}:{1:D2}:{2:D3}", min, (int)sec, millisec);

        if(t < 60f) // 60�� ���� �������
        {
            starImageDisplay.sprite = starImage[3];  // �� 3�� �̹���
        }
        else if(t < 80f)
        {
            starImageDisplay.sprite = starImage[2]; // starImageDisplay �� Image, �迭 ������ sprite �̷��� �׳� �ڿ� .sprite �� �����ع����� �ȴ�.
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



