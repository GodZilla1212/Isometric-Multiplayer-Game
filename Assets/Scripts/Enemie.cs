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
    [HideInInspector] public bool tengoLaBandera;

    private GameObject target;
    


	void Start () {

        tengoLaBandera = false;
        activateFlag.SetActive(false);

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
	}

     void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Flag")
        {
            Destroy(other.gameObject);
            activateFlag.SetActive(true); 
            tengoLaBandera = true;
            print("i touched something");
        }
    }
}
