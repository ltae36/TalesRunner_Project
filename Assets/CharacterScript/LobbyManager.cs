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

    public void Gamestart()  // ���� ���� ������ 1���� �ִ� ������ ��ȯ(trackScene)
    {
        SceneManager.LoadScene("1");
    }


    public void Gamequit()  // ���ø����̼� ����
    {
        Application.Quit();
    }
}
