using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponent : MonoBehaviour
{
    // ��Ȱ��ȭ�� ������Ʈ�� �����մϴ�.
    public MonoBehaviour componentToDisable;
    public GameObject player;
    public GameObject flash;

    public float woodenDollTime = 3;

    GameObject go;

    float currentTime = 0;

    private void Start()
    {      

        // Player �±׸� ���� ������Ʈ�� ã�� ������Ʈ�� �Ҵ��մϴ�.
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
        // ������Ʈ�� ��Ȱ��ȭ ���¶�� �ð��� �帣�� �� Ư�� �ð��� �����ϸ� ��Ȱ��ȭ�մϴ�.
        if (componentToDisable != null && !componentToDisable.enabled)
        {
            currentTime += Time.deltaTime;
            print(currentTime);
            if (currentTime > woodenDollTime)
            {
                componentToDisable.enabled = true;
                currentTime = 0f; // Ÿ�̸� ����
            }
        }
    }


    // Ʈ���� ������ ������ �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && componentToDisable != null)
        {
            if (flash.gameObject.activeInHierarchy == true)
            {
                other.gameObject.transform.position = transform.position;
                componentToDisable.enabled = false;
                currentTime = 0f; // Ÿ�̸� ����
            }
        }
        //if (other.gameObject == componentToDisable.gameObject)
        //{
        //    componentToDisable.enabled = false;
        //    //StartCoroutine(ReenableComponentAfterDelay());
        //}
    }


    //// ���� �ð��� ���� �� ������Ʈ�� �ٽ� Ȱ��ȭ�ϴ� Coroutine
    //private IEnumerator ReenableComponentAfterDelay()
    //{
    //    yield return new WaitForSeconds(woodenDollTime);
    //    if (componentToDisable != null)
    //    {
    //        componentToDisable.enabled = true;
    //    }
    //}

}
