using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    public AudioSource auidoSource;


    void Start()
    {
        
    }

    void Update()
    {
        LobbyBGM();  // 시작하면 로비 bgm 시작

        if (Input.anyKeyDown)     // 아무 키를 입력하aus
        {
            SceneManager.LoadScene("1");   // 씬 1번으로 이동
        }

        if (Input.GetKeyDown(KeyCode.Escape))   // esc를 누르면 어플리케이션 종료
        {
            Application.Quit();
        }
    }

    public void Gamestart()  // 게임 시작버튼  누를시 1번에 있는 씬으로 전환(trackScene)  ---- 게임 시작 버튼에 드래그&드롭
    {
        SceneManager.LoadScene("1");
    }


    //public void Gamequit()  //  quit 버튼을 누르면 어플리케이션 종료
    //{
    //    if(Input.GetButtonDown("Escape"))   
    //        {
    //           Application.Quit();
    //        }
    //}

    public void LobbyBGM()
    {
        if(auidoSource != null && !auidoSource.isPlaying)  //로비 bgm이 null 이 아니고 플레이 중이 아니라면
        {
            auidoSource.Play();
        }
    }


}
