using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaypointDebug : MonoBehaviour {

	//Metodo para renomear WP's//
	void RenameWPs(GameObject overlook)
	{
		GameObject[] gos;
	    gos = GameObject.FindGameObjectsWithTag("wp"); 
	    int i = 1;
	    foreach (GameObject go in gos)  
	    { 
	     	if(go != overlook)
	     	{
	     		go.name = "WP" + string.Format("{0:000}",i); 
	     		i++; 
	     	} 
	    }	
	}

	void OnDestroy()
	{
		RenameWPs(this.gameObject);
	}

	//Se o nome do objeto não for WayPoint, renomeia WP//
	void Start () {
		if(this.transform.parent.gameObject.name != "WayPoint") return;
		RenameWPs(null);
	}
	
	//Pegando o componente de texto para exibir o nome do objeto//
	void Update () {
		this.GetComponent<TextMesh>().text = this.transform.parent.gameObject.name;
	}
}
