using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gamestart()  // 게임 시작 누를시 1번에 있는 씬으로 전환(trackScene)
    {
        SceneManager.LoadScene("1");
    }


    public void Gamequit()  // 어플리케이션 종료
    {
        Application.Quit();
    }
}
