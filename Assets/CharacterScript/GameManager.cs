using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // �� �Ŵ���

public class GameManager : MonoBehaviour
{



    static public GameManager gm;

    public GameObject trackUI;   // track ui
    public GameObject goleinUI;  // golein �� ������ ui
                                 // 
    public Text timer;  // �ǽð� Ÿ�̸� text�� ����ĭ
    float timeLapes = 0f; // ����ð�
    bool istimerRunning = false; // Ÿ�̸� ���������� �ƴ���



    public Text countDown; // 321 start �� ���� Ÿ�̸� ����
    public Coroutine countDownCoroutine; // 321 start �ڷ�ƾ

    



    private float startTime;
       

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
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
     

        if (timer == null)  // ���� Ÿ�̸Ӱ� ����ٸ�
        {
            Debug.LogError("Ÿ�̸� ���峲");

        }
        else
        {
            ResetTimer(); // ���� start �� Ÿ�̸Ӹ���
            StartTimer(); // Ÿ�̸� ��ŸƮ
        }

        


    }

    void Update()
    {
        bgmStart();

        if (istimerRunning) // Ÿ�̸Ӱ� �����ִٸ�
        {
            timeLapes += Time.deltaTime; // ����ð��� �ǽð� �ð� ����
            UpdateTimeText(); // Ÿ�̸� �ؽ�Ʈ ������Ʈ
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
        istimerRunning = true; // Ÿ�̸Ӱ� �����ִ�.
    }

    void ResetTimer()
    {
        istimerRunning = false; // Ÿ�̸Ӱ� �����ִ�
    }

   

    public IEnumerator CountDown() // �÷��̾ start point �� ������ ī��Ʈ 3.2.1.Start�� ����ϴ� ui 
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

        Debug.Log("�ڷ�ƾ ����");
        yield break;

    }

    public void GoalIn() // goleinUI�� ����
    {

    }
    









    public void Restart() // �ٽ��ϱ� ��ư�� �Ҵ�
    {
        
        Input.GetKeyDown(KeyCode.F12);
    }

    public void Quit() // �׸��ϱ� ��ư�� �Ҵ�
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
