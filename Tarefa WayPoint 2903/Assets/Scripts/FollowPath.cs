using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //Variaveis//
    /*Transform goal;
    [Header ("Variaveis")]
    public float speed = 10.0f, accuracy = 1.0f, rotspeed = 2.0f;*/

    public GameObject wpManager;
    GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agent;

    /*GameObject currentNode;
    int currentWP = 0;
    Graph g;*/

    private void Start()
    {
        //Pegando os componentes e setando wps pra 0
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        /*g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];*/
    }

    //Pontos de WPS importantes
    public void GoToHeli() 
    {
        agent.SetDestination(wps[0].transform.position);
        /*g.AStar(currentNode, wps[0]); currentWP = 0;*/ 
    
    }
    public void GoToRuin() 
    {
        agent.SetDestination(wps[10].transform.position);
        /*g.AStar(currentNode, wps[10]); currentWP = 0;*/

    }
    public void GoToRock()
    {
        agent.SetDestination(wps[1].transform.position);
        /*g.AStar(currentNode, wps[1]); currentWP = 0;*/

    }


    private void LateUpdate()
    {
        /*//Se a distancia do proximo wp for igual a ACC, retorna//
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        {
            Debug.LogWarning("AAAAAAAAAAAAAAAAAA");
            return;
        }

        //o nó mais proximo
        currentNode = g.getPathPoint(currentWP);

        //Se tiver proximo o suficiente, move para ele
        if(Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position)<accuracy)
        {
            Debug.LogWarning("ta indo if2");
            currentWP++;
        }
        //Calculo padrão de movimentação q ja fizemos em outras aulas
        if(currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            //Parafernalha da rotação
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),Time.deltaTime * rotspeed);

            
        }
            //aplicando no translate desse objeto a velocidade vezes deltaTime
            this.transform.Translate(0, 0 , speed * Time.deltaTime);
            */
    }

}
