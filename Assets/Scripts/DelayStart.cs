using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStart : MonoBehaviour {

    public int coununtDown;
    public GameObject player_1;
    private GameObject player_2;

    void Start ()
    {
        player_1.GetComponent<PlayerController>().enabled = false;
        player_2 = GameObject.Find(PLAYER_NAME.ENEMY.ToString());
        player_2.GetComponent<Enemie>().enabled = false;
        Invoke("ActivatePlayers", coununtDown);
    }

    void ActivatePlayers()
    {
        player_1.GetComponent<PlayerController>().enabled = true;
        player_2.GetComponent<Enemie>().enabled = true;
    }

    


}
