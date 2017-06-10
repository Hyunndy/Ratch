using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//-------------------------------------------------------------
// NavMeshagent 붙은애들이 자꾸 미끄러져서 안미끄러지게 해주는 스크립트.
//-------------------------------------------------------------

public class NavMeshNotSlide : MonoBehaviour
{

    public float acceleration = 2f;
    public float deceleration = 60f;
    public float closeEnoughMeters = 4f;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = gameObject.GetComponentInChildren<NavMeshAgent>();
    }

    void Update()
    {
        if (navMeshAgent)
        {

            // speed up slowly, but stop quickly
            if (navMeshAgent.hasPath)
                navMeshAgent.acceleration = (navMeshAgent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;

        }
    }
}