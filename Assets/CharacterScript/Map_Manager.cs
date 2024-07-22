using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map_Manager : MonoBehaviour
{
    public GameObject[] mapPanels;
    private AudioSource[] mapAudioSources;
    private int currentIndex = 0;





    void Start()
    {
        mapAudioSources = new AudioSource[mapPanels.Length]; // 오디오 소스의 최대갯수 = 맵 패널의 최대갯수
        for (int i = 0; i < mapPanels.Length; i++)
        {
            mapAudioSources[i] = mapPanels[i].GetComponent<AudioSource>(); //   오디오 소스 i 와 맵 패널 i 를 배열순서를 동일화 시키고 오디오 소스 컴포넌트를 가져옴
                                                                           //   인스펙터에 오디오 클립을 맵 배열 순서대로 배치하면 됨    
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousMap();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextMap();
        }
    }

    void PreviousMap()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = mapPanels.Length - 1;
        }

        UpdateMapSelection();
    }

    void NextMap()
    {
        currentIndex++;
        if (currentIndex >= mapPanels.Length) // mappanel.length는 맵 패널 배열의 최대숫자, 여기서는 0 1 2 니까 3이다. 만약 현재 인데스가 맵패널보다 크거나 같다면 0번째로 초기화한다. 즉 오른쪽 끝에서 오른쪽으로 이동하면 0이된다.
        {
            currentIndex = 0;
        }
        UpdateMapSelection();
    }

    void UpdateMapSelection()
    {
        foreach(var audiosource in mapAudioSources)   // mapaudiosources 배열 안에 있는 audiosource에 접근해서
        {
            audiosource.Stop();  // 모든 오디오 소스 정지
            audiosource.gameObject.SetActive(false);  // 해당 오디오 소스를 가진 게임 오브젝트를 비활성화 
        }

        mapAudioSources[currentIndex].gameObject.SetActive(true);  // '현재선택된' 게임오브젝트를 활성화
        mapAudioSources[currentIndex].Play();  // 오디오 재생

        for (int i = 0; i < mapPanels.Length; i++)
        {
            mapPanels[i].SetActive(i == currentIndex); // 현재 선택된 맵 패널만 활성화
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("RacingTrack");
    }


    //void UpdateMapSelection  // 이건 맵 선택만
    //{
    //    for(int i = 0; i < mapPanels.Length; i++) //  만약 i가 0이고 맵 패널 최대값(3) 보다 작다면 1씩 더해라
    //    {
    //        if(i == currentIndex)// 만약 현재 맵이 1번이라면
    //        {
    //            mapPanels[i].SetActive(true);
    //        }
    //        else
    //        {
    //            mapPanels[i].SetActive(false);
    //        }


    //    }
    //}


}



