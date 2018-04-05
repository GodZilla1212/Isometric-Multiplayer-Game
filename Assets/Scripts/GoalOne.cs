using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PLAYER_NAME {
    PLAYER,
    ENEMY
}

public class GoalOne : MonoBehaviour {

    public int goals_enemy;
    public int goals_player;
    public Animator goalSign;
    public GameObject flag;
    public Transform positionFlag;
    public TextMesh points_Player;
    public TextMesh points_Enemy;
    public PLAYER_NAME playerField = PLAYER_NAME.PLAYER;
   

    void Start()
    {
        goals_enemy = 0;
        goals_player = 0;


}


    public void Goal<T>(T player, PLAYER_NAME type)
    {

        if(type == PLAYER_NAME.PLAYER)
        {
            MakeGoal(player as PlayerController);
        }
        else
        {
            MakeGoal(player as Enemie);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name.Equals(PLAYER_NAME.PLAYER.ToString()) && other.gameObject.GetComponent<PlayerController>().ptengoLaBandera == true)
        {
            Goal<PlayerController>(other.gameObject.GetComponent<PlayerController>(), PLAYER_NAME.PLAYER);

        }


        if (other.name.Equals(PLAYER_NAME.ENEMY.ToString()) && other.gameObject.GetComponent<Enemie>().tengoLaBandera == true)
        {
            Goal<Enemie>(other.gameObject.GetComponent<Enemie>(), PLAYER_NAME.ENEMY);

        }
    }

    private void MakeGoal(Enemie scriptP) {
            goals_enemy++;
            scriptP.activateFlag.SetActive(false);
            scriptP.tengoLaBandera = false;
            Vector3 point;
            if (RandomPoint(transform.position, 20f, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            }
            //print(point);
            Instantiate(flag, point, positionFlag.rotation);
            goalSign.SetTrigger("Celebration");
            points_Enemy.text = "" + goals_enemy;

    }


    private void MakeGoal(PlayerController scriptP)
    {
        goals_player++;
        scriptP.p_1activateFlag.SetActive(false);
        scriptP.ptengoLaBandera = false;
        Vector3 point;
       if (RandomPoint(transform.position, 20f, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
        }
        //print(point);
        Instantiate(flag, point, positionFlag.rotation);
        goalSign.SetTrigger("Celebration");
        points_Player.text = "" + goals_player;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 60; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = positionFlag.position;
        return false;
    }


}