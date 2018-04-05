using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearTrap : MonoBehaviour {

    public float stoppetTime;

    private Animator bearTrap;
    private NavMeshAgent agent;

	void Start ()
    {
        bearTrap = GetComponent<Animator>();
		
	}


    private void OnTriggerEnter(Collider other)
    {
        agent = other.gameObject.GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        bearTrap.SetBool("icatchyou", true);
        Invoke("RetornWay", stoppetTime);
    }

    void RetornWay()
    {
        agent.isStopped = false;
        Destroy(gameObject);
    }
}
