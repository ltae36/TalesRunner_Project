using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    public AudioSource lobbyBGM;


    void Start()
    {
        
    }

    void Update()
    {
        LobbyBGM();
    }

    public void Gamestart()  // 게임 시작 누를시 1번에 있는 씬으로 전환(trackScene)
    {
        SceneManager.LoadScene("1");
    }


    public void Gamequit()  // 어플리케이션 종료
    {
        if(Input.GetButtonDown("Escape"))   
            {
               Application.Quit();
            }
    }

    public void LobbyBGM()
    {
        if(lobbyBGM != null && !lobbyBGM.isPlaying)  //로비 bgm이 null 이 아니고 플레이 중이 아니라면
        {
            lobbyBGM.Play();
        }
    }


}
