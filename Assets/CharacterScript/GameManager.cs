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
}
