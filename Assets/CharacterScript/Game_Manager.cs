using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game_Manager : MonoBehaviour
{
    public static Game_Manager gm; // 다른 스크립트에서 game manager  에 접근가능

    private AudioSource audiosource;
    


    private void Awake() // 싱글톤 선언
    {
        if(gm != null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        BGMstart();




    }




    void Update()
    {
        
    }

    public void GameRestart()  // 다시하기 
    {
        SceneManager.LoadScene("RacingTrack");
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void BGMstart()
    {
        if (audiosource != null)
        {
            Debug.Log("Audio playing: " + audiosource.isPlaying);

            audiosource.Play();
        }
    }

    
}
