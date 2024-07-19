using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    public AudioSource auidoSource;
    public AudioClip bgm;

    //하이어라키에 있는 버튼 설정
    GameObject GameStart;

    //로그인 패널
    public GameObject loginPanel;
    public InputField userNameInput;      // 아이디 입력칸
    public InputField userPasswordInput;  // 비밀번호입력칸

    public Button login; // 로그인 버튼
    public Button signin; // 회원가입 버튼

    private const string userID = "test";
    private const string passwordID = "qlqjs";

    //게임시작 버튼
    public GameObject gameStartPanel;
    public Button gameStart; // 게임시작 버튼

    public Text wrong; // 에러메세지
    private float wrongmessageTime = 3f;


    void Start()
    {

        auidoSource = GetComponent<AudioSource>();

        loginPanel.SetActive(true);
        gameStartPanel.SetActive(false);

        LobbyBGM();  // 시작하면 로비 bgm 시작

    }

    void Update()
    {
       
        


    }

    public void OnLoginButtonClicked()    // 로그인 버튼을 눌렀을때 작동되는 이벤트 함수
    {
        if(IsValidUser(userNameInput.text, userPasswordInput.text))   // 만약 userNameInput 과 userPasswordInput에 입력된 값이 isvaliduser함수의 매개변수와 맞다면
        {
            showgameStartPanel();  //  showgameStartPanel 함수를 실행해라
        }
        else
        {
            Debug.Log("틀린 아이디거나 비밀번호입니다.");
           
        }
    }

    private bool IsValidUser(string username, string password)  // 올바른 유저네임, 비밀번호가 맞는지 아닌지
    {
        return username == userID && password == passwordID ;    // IsValidUSer 매개변수에 위에서 선언한 id와 비밀번호를 넣는다.
    }


    private void showgameStartPanel()   // 로그인이 되서 로그인 버튼을 누를시 실행될 함수
    {
        loginPanel.SetActive(false);     // 로그인 패널을 숨기고
        gameStartPanel.SetActive(true);  // 게임시작 패널을 팝업시켜라
    }

    private void wrongIdPassword() // 잘못된 아이디 비번 입력시 출력
    {
        wrong = GetComponent<Text>(); ;
    }









    public void Gamestart()  // 게임 시작버튼  누를시 1번에 있는 씬으로 전환(trackScene)  ---- 게임 시작 버튼에 드래그&드롭
    {
        SceneManager.LoadScene("RacingTrack");
    }


    public void Gamequit()  //  quit 버튼을 누르면 어플리케이션 종료
    {
        Application.Quit();

    }

    public void LobbyBGM()
    {
        auidoSource = GetComponent<AudioSource>();

        if(auidoSource != null && !auidoSource.isPlaying)  //로비 bgm이 null 이 아니고 플레이 중이 아니라면
        {
            auidoSource.Play();
          
        }
    }

    

}
