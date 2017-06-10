// Patrol.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

//---------------------------------------------------------------------
// 적에게 순찰루트를 정해주는 스크립트!
// 사용법:
// 빈 게임 오브젝트 생성하고 원하는 루트의 꼭지점에 위치시킨다.
// Patrol스크립트를 적에게 적용한 뒤,
// 위치시킨 빈 게임 오브젝트를 POINTS에 넣어주면 된다!!!! 
//---------------------------------------------------------------------

public class Patrol : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (agent.remainingDistance < 0.3f)
            GotoNextPoint();
    }
}