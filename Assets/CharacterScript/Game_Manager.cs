using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game_Manager : MonoBehaviour
{
    public static Game_Manager gm; // �ٸ� ��ũ��Ʈ���� game manager  �� ���ٰ���

    private AudioSource audiosource;

    public Text countdownText;



    private void Awake() // �̱��� ����
    {
        if (gm != null)
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

    public void GameRestart()  // �ٽ��ϱ� 
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

  

    public IEnumerator StartCount()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countdownText.text = "";
    }



}
