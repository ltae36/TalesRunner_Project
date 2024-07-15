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
        LobbyBGM();  // �����ϸ� �κ� bgm ����

        if (Input.anyKeyDown)     // �ƹ� Ű�� �Է���aus
        {
            SceneManager.LoadScene("1");   // �� 1������ �̵�
        }

        if (Input.GetKeyDown(KeyCode.Escape))   // esc�� ������ ���ø����̼� ����
        {
            Application.Quit();
        }
    }

    public void Gamestart()  // ���� ���۹�ư  ������ 1���� �ִ� ������ ��ȯ(trackScene)  ---- ���� ���� ��ư�� �巡��&���
    {
        SceneManager.LoadScene("1");
    }


    //public void Gamequit()  //  quit ��ư�� ������ ���ø����̼� ����
    //{
    //    if(Input.GetButtonDown("Escape"))   
    //        {
    //           Application.Quit();
    //        }
    //}

    public void LobbyBGM()
    {
        if(auidoSource != null && !auidoSource.isPlaying)  //�κ� bgm�� null �� �ƴϰ� �÷��� ���� �ƴ϶��
        {
            auidoSource.Play();
        }
    }


}
