using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene() // ���������ΰ��� �Լ�
    {
        SceneManager.LoadScene("1");
    }

    public void GameQuit() // ��������,
    {
        Application.Quit();
    }
}


