using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Criando um ENUM//
[System.Serializable]

public struct link
{
    public enum direction { UNI, BI};
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}


public class WPManager : MonoBehaviour
{
    //Arrays e variavel do gráfico do waypoint//
    public GameObject[] waypoints;
    public link[] links;
    public Graph graph = new Graph();

    private void Start()
    {
        //se waypoints for maior q 0, para cada wp criar um node, então pra cada link uma direção//
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            { graph.AddNode(wp); }
            foreach (link i in links)
            {
                graph.AddEdge(i.node1, i.node2);
                if (i.dir == link.direction.BI)
                {
                    graph.AddEdge(i.node2, i.node1);
                }
            }
        }

    }

    private void Update()
    {
        //Debugando a linha do grafico
        graph.debugDraw();
    }

}
