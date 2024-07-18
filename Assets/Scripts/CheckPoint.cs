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
        #region �迭 Ȱ��
        ////"CheckPoint"�±׸� ���� ������Ʈ�� �ڵ����� �迭�� ����
        //checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");

        //// checkPoint���� ���̸� ����Ѵ�.
        //for(int i = 0; i < checkPoints.Length - 1; i++) 
        //{
        //    track += Vector3.Distance(checkPoints[i].transform.position, checkPoints[i + 1].transform.position);
        //    distance.Add(Vector3.Distance(checkPoints[i].transform.position, checkPoints[i + 1].transform.position));
        //}
        //// �����̴��� ���� maxvalue���� üũ����Ʈ���� ���̸� ��� ���� ��
        //distanceSlider.maxValue = track;
        //distanceSlider.value = 0;
        #endregion

        // ���� ������ ���� ���� ���� �Ÿ��� ����Ͽ� maxValue���� ���Ѵ�.
        float distance = Vector3.Distance(startPoint.transform.position, goalPoint.transform.position);
        distanceSlider.maxValue = distance;
        distanceSlider.value = 0;
    }

    void Update()
    {
        float playerDist = Vector3.Distance(player.transform.position, goalPoint.transform.position);
        distanceSlider.value = playerDist;
        #region �迭 Ȱ��2
        //float closestDistance = Mathf.Infinity;

        //// �÷��̾� ��ġ�� ù��° üũ����Ʈ ��ġ ���� �Ÿ��� ���� �����̴��� �����δ�.
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
        // �÷��̾ ���� üũ ����Ʈ�� �����Ѵٸ� ù��° üũ����Ʈ, �ι�° üũ����Ʈ ���� �Ÿ� �� + �ι�° üũ����Ʈ�� �÷��̾� ��ġ ���� �Ÿ� ���� ����Ѵ�.
        #endregion

    }
}
