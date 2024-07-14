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

    public void Gamestart()  // ���� ���� ������ 1���� �ִ� ������ ��ȯ(trackScene)
    {
        SceneManager.LoadScene("1");
    }


    public void Gamequit()  // ���ø����̼� ����
    {
        if(Input.GetButtonDown("Escape"))   
            {
               Application.Quit();
            }
    }

    public void LobbyBGM()
    {
        if(lobbyBGM != null && !lobbyBGM.isPlaying)  //�κ� bgm�� null �� �ƴϰ� �÷��� ���� �ƴ϶��
        {
            lobbyBGM.Play();
        }
    }


}
