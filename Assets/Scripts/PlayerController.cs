using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public GameObject p_1activateFlag;
    public GameObject bearTrap;
    public float timeUnfreeze = 2;
    public int limitBearTrap;


    [HideInInspector]
    public bool ptengoLaBandera;
    [HideInInspector]
    public bool imFreeze;


    private Rigidbody rb;
    
    private int countBearTrap;

	void Start ()
    {
        p_1activateFlag.SetActive(false);
        ptengoLaBandera = false;
        imFreeze = false;
        rb = GetComponent<Rigidbody>();
	}
	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (countBearTrap < limitBearTrap )
                {
                    Instantiate(bearTrap, hit.point, bearTrap.transform.rotation);
                    countBearTrap++;
                }
              
            }
        }

        if (Input.touchCount > 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (imFreeze)
        {
            agent.isStopped = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("Unfreeze", timeUnfreeze);
        }

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Flag")
        {
            Destroy(other.gameObject);
            p_1activateFlag.SetActive(true);
            ptengoLaBandera = true;
            
        }
    }

    void Unfreeze()
    {
        agent.isStopped = false;
        rb.constraints = RigidbodyConstraints.None;
        imFreeze = false;
    }
}
