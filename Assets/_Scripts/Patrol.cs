using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol: MonoBehaviour
{
    public Transform[] pathPoints;
    private int destinationPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoToPoint();
    }

    void GotoToPoint()
    {        
        if(pathPoints.Length == 0) return;
        agent.destination = pathPoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % pathPoints.Length;
    }

    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.3f)
            GotoToPoint();
    }
}