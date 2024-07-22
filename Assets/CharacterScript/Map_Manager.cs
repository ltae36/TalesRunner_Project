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
        mapAudioSources = new AudioSource[mapPanels.Length]; // ����� �ҽ��� �ִ밹�� = �� �г��� �ִ밹��
        for (int i = 0; i < mapPanels.Length; i++)
        {
            mapAudioSources[i] = mapPanels[i].GetComponent<AudioSource>(); //   ����� �ҽ� i �� �� �г� i �� �迭������ ����ȭ ��Ű�� ����� �ҽ� ������Ʈ�� ������
                                                                           //   �ν����Ϳ� ����� Ŭ���� �� �迭 ������� ��ġ�ϸ� ��    
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
        if (currentIndex >= mapPanels.Length) // mappanel.length�� �� �г� �迭�� �ִ����, ���⼭�� 0 1 2 �ϱ� 3�̴�. ���� ���� �ε����� ���гκ��� ũ�ų� ���ٸ� 0��°�� �ʱ�ȭ�Ѵ�. �� ������ ������ ���������� �̵��ϸ� 0�̵ȴ�.
        {
            currentIndex = 0;
        }
        UpdateMapSelection();
    }

    void UpdateMapSelection()
    {
        foreach(var audiosource in mapAudioSources)   // mapaudiosources �迭 �ȿ� �ִ� audiosource�� �����ؼ�
        {
            audiosource.Stop();  // ��� ����� �ҽ� ����
            audiosource.gameObject.SetActive(false);  // �ش� ����� �ҽ��� ���� ���� ������Ʈ�� ��Ȱ��ȭ 
        }

        mapAudioSources[currentIndex].gameObject.SetActive(true);  // '���缱�õ�' ���ӿ�����Ʈ�� Ȱ��ȭ
        mapAudioSources[currentIndex].Play();  // ����� ���

        for (int i = 0; i < mapPanels.Length; i++)
        {
            mapPanels[i].SetActive(i == currentIndex); // ���� ���õ� �� �гθ� Ȱ��ȭ
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("RacingTrack");
    }


    //void UpdateMapSelection  // �̰� �� ���ø�
    //{
    //    for(int i = 0; i < mapPanels.Length; i++) //  ���� i�� 0�̰� �� �г� �ִ밪(3) ���� �۴ٸ� 1�� ���ض�
    //    {
    //        if(i == currentIndex)// ���� ���� ���� 1���̶��
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



