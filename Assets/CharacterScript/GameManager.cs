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
        
    }

    void Timer()
    {
        
    }

    void restart() // �ٽ��ϱ� ��ư || f12 ������ �ٽ��ϱ�
    {
        TrackUI.SetActive(true);
        Input.GetKeyDown(KeyCode.F12);
    }

    public void quit() // �׸��ϱ� ��ư || esc ������ ������
    {
        Application.Quit();

        // esc��?

    }

}
