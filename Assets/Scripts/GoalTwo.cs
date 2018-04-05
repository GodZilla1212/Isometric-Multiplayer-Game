using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTwo : MonoBehaviour {

    public int goals;
    public Animator goalSign;
    public GameObject flag;
    public Transform positionFlag;
    private Enemie scriptE;


	void Start ()
    {
        goals = 0;
        
		
	}

    private void OnTriggerEnter(Collider other)
    {
         
        if (other.gameObject.CompareTag(PLAYER_NAME.ENEMY.ToString()) && other.gameObject.GetComponent<Enemie>().tengoLaBandera == true)
        {
            goals ++;
            scriptE = other.gameObject.GetComponent<Enemie>();
            scriptE.activateFlag.SetActive(false);
            scriptE.tengoLaBandera = false;
            Instantiate(flag, positionFlag.position, positionFlag.rotation);
            goalSign.SetTrigger("Celebration");
        }
    }

}
