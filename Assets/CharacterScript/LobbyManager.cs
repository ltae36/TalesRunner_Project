using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    public AudioSource auidoSource;
    //���̾��Ű�� �ִ� ��ư ����
    GameObject GameStart;



    void Start()
    {
        
    }

    void Update()
    {
        LobbyBGM();  // �����ϸ� �κ� bgm ����

        
        Gamestart();

        Gamequit();



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
