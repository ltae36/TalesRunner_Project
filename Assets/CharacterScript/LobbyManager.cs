using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    public AudioSource auidoSource;
    public AudioClip bgm;

    //���̾��Ű�� �ִ� ��ư ����
    GameObject GameStart;

    //�α��� �г�
    public GameObject loginPanel;
    public InputField userNameInput;      // ���̵� �Է�ĭ
    public InputField userPasswordInput;  // ��й�ȣ�Է�ĭ

    public Button login; // �α��� ��ư
    public Button signin; // ȸ������ ��ư

    private const string userID = "test";
    private const string passwordID = "qlqjs";

    //���ӽ��� ��ư
    public GameObject gameStartPanel;
    public Button gameStart; // ���ӽ��� ��ư

    public Text wrong; // �����޼���
    private float wrongmessageTime = 3f;


    void Start()
    {

        auidoSource = GetComponent<AudioSource>();

        loginPanel.SetActive(true);
        gameStartPanel.SetActive(false);

        LobbyBGM();  // �����ϸ� �κ� bgm ����

    }

    void Update()
    {
       
        


    }

    public void OnLoginButtonClicked()    // �α��� ��ư�� �������� �۵��Ǵ� �̺�Ʈ �Լ�
    {
        if(IsValidUser(userNameInput.text, userPasswordInput.text))   // ���� userNameInput �� userPasswordInput�� �Էµ� ���� isvaliduser�Լ��� �Ű������� �´ٸ�
        {
            showgameStartPanel();  //  showgameStartPanel �Լ��� �����ض�
        }
        else
        {
            Debug.Log("Ʋ�� ���̵�ų� ��й�ȣ�Դϴ�.");
           
        }
    }

    private bool IsValidUser(string username, string password)  // �ùٸ� ��������, ��й�ȣ�� �´��� �ƴ���
    {
        return username == userID && password == passwordID ;    // IsValidUSer �Ű������� ������ ������ id�� ��й�ȣ�� �ִ´�.
    }


    private void showgameStartPanel()   // �α����� �Ǽ� �α��� ��ư�� ������ ����� �Լ�
    {
        loginPanel.SetActive(false);     // �α��� �г��� �����
        gameStartPanel.SetActive(true);  // ���ӽ��� �г��� �˾����Ѷ�
    }

    private void wrongIdPassword() // �߸��� ���̵� ��� �Է½� ���
    {
        wrong = GetComponent<Text>(); ;
    }









    public void Gamestart()  // ���� ���۹�ư  ������ 1���� �ִ� ������ ��ȯ(trackScene)  ---- ���� ���� ��ư�� �巡��&���
    {
        SceneManager.LoadScene("RacingTrack");
    }


    public void Gamequit()  //  quit ��ư�� ������ ���ø����̼� ����
    {
        Application.Quit();

    }

    public void LobbyBGM()
    {
        auidoSource = GetComponent<AudioSource>();

        if(auidoSource != null && !auidoSource.isPlaying)  //�κ� bgm�� null �� �ƴϰ� �÷��� ���� �ƴ϶��
        {
            auidoSource.Play();
          
        }
    }

    

}
