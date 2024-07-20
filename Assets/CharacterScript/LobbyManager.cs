using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // legacy text
using UnityEngine.SceneManagement; 
using UnityEngine.Rendering.LookDev;

public class LobbyManager : MonoBehaviour
{
    public GameObject LoginPanel; // �α����г�
    //public GameObject LoginButton; // �α��ι�ư
    public InputField LoginInput;
    public InputField PasswordInput;

    public Text errorText; // �����ؽ�Ʈ ���

    private string ID = "test";
    private string password1 = "qlqjs";





    public GameObject GameStartPanel; // ���ӽ����г�
    public GameObject GameStartButton;



    private AudioSource auidoSource;




    void Start()
    {
        StartScreen();
    }

    void Update()
    {
        LobbyBGM();  // �����ϸ� �κ� bgm ����


        



    }

    public void GamestartButton()  // ���� ���۹�ư  ������ 1���� �ִ� ������ ��ȯ(trackScene)  ---- ���� ���� ��ư�� �巡��&���
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
        if (auidoSource != null && !auidoSource.isPlaying)  //�κ� bgm�� null �� �ƴϰ� �÷��� ���� �ƴ϶��
        {
            auidoSource.Play();
        }
    }




    private bool IsValidUser(string username, string password)
    {

        if (username == ID && password == password1)
        {
            return true; // ���̵�� ��й�ȣ�� ��ġ�� ��� true ��ȯ
        }
        else
        {
            return false; // ��ġ���� ���� ��� false ��ȯ
        }
    }
   
   


    public void LoginbuttonClick()  // �α��� ��ư�� ������ ������ �Լ�
    {
        if(IsValidUser( ID, password1))
            {

            Debug.Log(" �α��� ���� �۵�");

            LoginPanel.SetActive(false);
            GameStartPanel.SetActive(true);

            errorText.text = "";
            }
        else
        {
            Debug.Log("�α��� ���� ���");

            Text errorText;

            StartCoroutine(ErrorTextTime(3f));
        }
       
    }

    private IEnumerator ErrorTextTime(float time)
    {
       yield return new WaitForSeconds(time);  // ������ �ð����� ���

        errorText.text = "";
    }









}
