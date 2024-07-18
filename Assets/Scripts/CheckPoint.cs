using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    //private GameObject[] checkPoints;
    //private List<float> distance = new List<float>();

    public Transform player;
    public Slider distanceSlider;

    //float track;
    //float playerDist;

    public Transform goalPoint;
    public Transform startPoint;

    void Start()
    {
        #region 배열 활용
        ////"CheckPoint"태그를 가진 오브젝트를 자동으로 배열에 저장
        //checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");

        //// checkPoint간의 길이를 계산한다.
        //for(int i = 0; i < checkPoints.Length - 1; i++) 
        //{
        //    track += Vector3.Distance(checkPoints[i].transform.position, checkPoints[i + 1].transform.position);
        //    distance.Add(Vector3.Distance(checkPoints[i].transform.position, checkPoints[i + 1].transform.position));
        //}
        //// 슬라이더의 끝인 maxvalue값은 체크포인트간의 길이를 모두 더한 값
        //distanceSlider.maxValue = track;
        //distanceSlider.value = 0;
        #endregion

        // 시작 지점과 도착 지점 간의 거리를 계산하여 maxValue값을 정한다.
        float distance = Vector3.Distance(startPoint.transform.position, goalPoint.transform.position);
        distanceSlider.maxValue = distance;
        distanceSlider.value = 0;
    }

    void Update()
    {
        float playerDist = Vector3.Distance(player.transform.position, goalPoint.transform.position);
        distanceSlider.value = playerDist;
        #region 배열 활용2
        //float closestDistance = Mathf.Infinity;

        //// 플레이어 위치와 첫번째 체크포인트 위치 간의 거리에 맞춰 슬라이더가 움직인다.
        //foreach (GameObject pos in checkPoints) 
        //{
        //    int num = 0;
        //    playerDist = Vector3.Distance(player.transform.position, pos.transform.position);

        //    if(playerDist < closestDistance) 
        //    {
        //        closestDistance = playerDist;
        //    }
        //    distanceSlider.value = closestDistance;

        //}
        //playerDist = Vector3.Distance(checkPoints[])
        // 플레이어가 다음 체크 포인트에 도달한다면 첫번째 체크포인트, 두번째 체크포인트 간의 거리 값 + 두번째 체크포인트와 플레이어 위치 간의 거리 값을 계산한다.
        #endregion

    }
}
