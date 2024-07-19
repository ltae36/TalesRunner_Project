using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject player;
    private Final move;

    // Start is called before the first frame update
    void Start()
    {
        if(player != null) 
        {
            move = player.GetComponent<Final>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && move != null) 
        {
            move.enabled = false;
        }
    }
}
