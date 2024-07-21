using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponent : MonoBehaviour
{
    // 비활성화할 컴포넌트를 지정합니다.
    public MonoBehaviour componentToDisable;
    public GameObject player;
    public GameObject flash;

    public float woodenDollTime = 3;

    GameObject go;

    float currentTime = 0;

    private void Start()
    {      

        // Player 태그를 가진 오브젝트를 찾아 컴포넌트를 할당합니다.
        if (componentToDisable == null)
        {
            GameObject go = GameObject.FindWithTag("Player");
            if (go != null)
            {
                player = go;
                componentToDisable = player.GetComponent<MonoBehaviour>();
                if (componentToDisable == null)
                {
                    Debug.LogError("The specified component is not found on the player.");
                }
            }
            else
            {
                Debug.LogError("Player object with tag 'Player' not found.");
            }
        }
    }

    private void Update()
    {
        // 컴포넌트가 비활성화 상태라면 시간을 흐르게 해 특정 시간에 도달하면 재활성화합니다.
        if (componentToDisable != null && !componentToDisable.enabled)
        {
            currentTime += Time.deltaTime;
            print(currentTime);
            if (currentTime > woodenDollTime)
            {
                componentToDisable.enabled = true;
                currentTime = 0f; // 타이머 리셋
            }
        }
    }


    // 트리거 영역에 들어왔을 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && componentToDisable != null)
        {
            if (flash.gameObject.activeInHierarchy == true)
            {
                other.gameObject.transform.position = transform.position;
                componentToDisable.enabled = false;
                currentTime = 0f; // 타이머 리셋
            }
        }
        //if (other.gameObject == componentToDisable.gameObject)
        //{
        //    componentToDisable.enabled = false;
        //    //StartCoroutine(ReenableComponentAfterDelay());
        //}
    }


    //// 일정 시간이 지난 후 컴포넌트를 다시 활성화하는 Coroutine
    //private IEnumerator ReenableComponentAfterDelay()
    //{
    //    yield return new WaitForSeconds(woodenDollTime);
    //    if (componentToDisable != null)
    //    {
    //        componentToDisable.enabled = true;
    //    }
    //}

}
