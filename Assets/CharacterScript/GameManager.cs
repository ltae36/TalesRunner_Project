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
    private bool isRunning;




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
}
