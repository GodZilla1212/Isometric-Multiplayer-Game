using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patron : MonoBehaviour {

    public Transform[] points;
    //public GameObject target;

    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
       // RaycastHit hit;
       // Physics.Raycast(transform.position, target.transform.position, out hit);

        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}

