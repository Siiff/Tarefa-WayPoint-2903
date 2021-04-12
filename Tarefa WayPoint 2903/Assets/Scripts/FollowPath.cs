using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public GameObject wpManager;
    GameObject[] wps;
    //agente do navmesh utilizado para nova
    UnityEngine.AI.NavMeshAgent agent;


    private void Start()
    {
        //Pegando os componentes
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    //Pontos de WPS importantes
    public void GoToHeli() 
    {
        agent.SetDestination(wps[0].transform.position);
    }
    public void GoToRuin() 
    {
        agent.SetDestination(wps[10].transform.position);

    }
    public void GoToRock()
    {
        agent.SetDestination(wps[1].transform.position);

    }

}
