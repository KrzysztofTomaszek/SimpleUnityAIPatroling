using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;


public class Patrol: MonoBehaviour
{
    public Transform[] pathPoints;
    private int destinationPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void GotoToPoint()
    {        
        agent.destination = pathPoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % pathPoints.Length;
    }

    void AddPatrolPoint(Transform patrolPoint)
    {
        Array.Resize(ref pathPoints, pathPoints.Length + 1);
        pathPoints[pathPoints.Length] = patrolPoint;         
        enabled = true;
    }

    void Update()
    {
        if(pathPoints.Length == 0) enabled = false;
        if(!agent.pathPending && agent.remainingDistance < 0.3f && pathPoints.Length != 0) GotoToPoint();        
    }
}
