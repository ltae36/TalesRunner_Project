using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene() // 다음씬으로가는 함수
    {
        SceneManager.LoadScene("1");
    }

    public void GameQuit() // 게임종료,
    {
        Application.Quit();
    }
}


