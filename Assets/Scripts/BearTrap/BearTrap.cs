using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearTrap : MonoBehaviour {

    public float stoppetTime;
    public GameObject animation2dTrap;
    public GameObject myFather;

    private Animator bearTrap;
    

	void Start ()
    {
        bearTrap = GetComponent<Animator>();
        animation2dTrap.SetActive(false);
	}
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_1"))
        {
            other.gameObject.GetComponent<PlayerController>().imFreeze = true;
            bearTrap.SetBool("icatchyou", true);
            animation2dTrap.SetActive(true);
            Invoke("RetornWay", stoppetTime);
        }
        if (other.gameObject.CompareTag("Player_2"))
        {
            other.gameObject.GetComponent<Enemie>().imFreeze = true;
            bearTrap.SetBool("icatchyou", true);
            animation2dTrap.SetActive(true);
            Invoke("RetornWay", stoppetTime);
        }



    }                                                                                            
                                                                                                 
    void RetornWay()                                                                             
    {                                                                 
        Destroy(myFather);                                                                       
    }                                                                                            
}
