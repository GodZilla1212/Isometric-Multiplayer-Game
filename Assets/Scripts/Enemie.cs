using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour {

    public Transform myZone;
    public Transform SpawnZone;
    public GameObject activateFlag;
    public NavMeshAgent enemy;
    public GameObject otherPlayer;
    public float timeUnfreeze = 2;

    [HideInInspector]
    public bool tengoLaBandera;
    [HideInInspector]
    public bool imFreeze;

    private GameObject target;
    private Rigidbody rb;
    



    void Start () {

        tengoLaBandera = false;
        activateFlag.SetActive(false);
        rb = GetComponent<Rigidbody>();

    }
	
	
	void Update ()
    {

        target = GameObject.FindGameObjectWithTag("Flag");

        if ( !tengoLaBandera)
        {
            if (target == null)
            {
                if (otherPlayer.GetComponent<PlayerController>().ptengoLaBandera == true)
                {
                    enemy.SetDestination(otherPlayer.transform.position);
                }
                else
                {
                    enemy.SetDestination(SpawnZone.position);
                }
            }
            else
            {
                enemy.SetDestination(target.transform.position);
            }
        }
        else
        {
            enemy.SetDestination(myZone.position);
        }

        if (imFreeze == true)
        {
            enemy.isStopped = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("Unfreeze", timeUnfreeze);
        }
    }

     void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Flag")
        {
            Destroy(other.gameObject);
            activateFlag.SetActive(true); 
            tengoLaBandera = true;

        }
    }

    void Unfreeze()
    {
        enemy.isStopped = false;
        rb.constraints = RigidbodyConstraints.None;
        imFreeze = false;
    }
}
