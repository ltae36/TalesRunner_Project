using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

    public GameManager gm;


    void Start()
    {
        GameManager gm = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gm != null)
            {
                Debug.Log("¥Í¿Ω");
                StartCoroutine(GameManager.gm.CountDown());

                StopCoroutine(GameManager.gm.CountDown());

            }

            


        }
    }
}
