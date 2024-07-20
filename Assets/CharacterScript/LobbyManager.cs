using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // legacy text
using UnityEngine.SceneManagement; 
using UnityEngine.Rendering.LookDev;

public class LobbyManager : MonoBehaviour
{
    public GameObject LoginPanel; // 로그인패널
    //public GameObject LoginButton; // 로그인버튼
    public InputField LoginInput;
    public InputField PasswordInput;

    public Text errorText; // 에러텍스트 등록

    private string ID = "test";
    private string password1 = "qlqjs";





    public GameObject GameStartPanel; // 게임시작패널
    public GameObject GameStartButton;



    private AudioSource auidoSource;




    void Start()
    {
        StartScreen();
    }

    void Update()
    {
        LobbyBGM();  // 시작하면 로비 bgm 시작


        



    }

    public void GamestartButton()  // 게임 시작버튼  누를시 1번에 있는 씬으로 전환(trackScene)  ---- 게임 시작 버튼에 드래그&드롭
    {
        SceneManager.LoadScene("RacingTrack");
    }


    private void StartScreen()
    {
        LoginPanel.SetActive(true);

        GameStartPanel.SetActive(false);
    }


    public void LobbyBGM()
    {
        if (auidoSource != null && !auidoSource.isPlaying)  //로비 bgm이 null 이 아니고 플레이 중이 아니라면
        {
            auidoSource.Play();
        }
    }




    private bool IsValidUser(string username, string password)
    {

        if (username == ID && password == password1)
        {
            return true; // 아이디와 비밀번호가 일치할 경우 true 반환
        }
        else
        {
            return false; // 일치하지 않을 경우 false 반환
        }
    }
   
   


    public void LoginbuttonClick()  // 로그인 버튼을 누르면 실행할 함수
    {
        if(IsValidUser( ID, password1))
            {

            Debug.Log(" 로그인 정상 작동");

            LoginPanel.SetActive(false);
            GameStartPanel.SetActive(true);

            errorText.text = "";
            }
        else
        {
            Debug.Log("로그인 실패 출력");

            Text errorText;

            StartCoroutine(ErrorTextTime(3f));
        }
       
    }

    private IEnumerator ErrorTextTime(float time)
    {
       yield return new WaitForSeconds(time);  // 지정된 시간동안 대기

        errorText.text = "";
    }









}
