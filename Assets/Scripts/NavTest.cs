using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Transform goal;
        
    void Start()
    {
        
    }

    void Update()
    {
        agent.SetDestination(goal.position);
    }
}
