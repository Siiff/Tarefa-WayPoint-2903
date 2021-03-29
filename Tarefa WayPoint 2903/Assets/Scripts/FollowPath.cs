﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //Variaveis//
    Transform goal;
    [Header ("Variaveis")]
    public float speed = 5.0f, accuracy = 1.0f, rotspeed = 5.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    private void Start()
    {
        //Pegando os componentes e setando wps pra 0
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }

    //Pontos de WPS importantes
    public void GoToHeli() 
    { 
        g.AStar(currentNode, wps[0]); currentWP = 0; 
    
    }
    public void GoToRuin() 
    { 
        g.AStar(currentNode, wps[4]); currentWP = 0; 
    
    }
    

    private void LateUpdate()
    {
        //Se a distancia do proximo wp for igual a ACC, retorna//
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        {
            Debug.LogWarning("AAAAAAAAAAAAAAAAAA");
            return;
        }

        //o nó mais proximo
        currentNode = g.getPathPoint(currentWP);

        //Se tiver proximo o suficiente, move para ele
        if(Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position)>accuracy)
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

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),Time.deltaTime *rotspeed);

            
        }
            //aplicando no translate desse objeto a velocidade vezes deltaTime
            this.transform.Translate(0, 0 , speed * Time.deltaTime);
            
    }

}
