using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsGen : MonoBehaviour {

	public GameObject treeA;
	public GameObject treeB;
	int x;
	void start(){
		x = -10;
	Vector3 treeAPos=new Vector3(0,0,0);
	Vector3 treeBPos=new Vector3(0,0,0);
		Debug.Log (x);
		for (;x<80;x+=30){
			Debug.Log ("test");
		treeAPos = new Vector3 (40, -4, (x + 80));
	GameObject treeAIns = Instantiate (treeA);
	treeAIns.transform.position = treeAPos;

	treeAPos = new Vector3 (40, -4, (x + 85));
	GameObject treeCIns = Instantiate (treeA);
	treeCIns.transform.position = treeAPos;

	treeBPos = new Vector3 (-42, -4, (x+ 95));
	GameObject treeBIns = Instantiate (treeB);
	treeBIns.transform.position = treeBPos;

	treeBPos = new Vector3 (-42, -4, (x+ 100));
	GameObject treeDIns = Instantiate (treeB);
	treeDIns.transform.position = treeBPos;

	treeAPos = new Vector3 (-42, -4, (x+ 80));
	GameObject treeEIns = Instantiate (treeA);
	treeEIns.transform.position = treeAPos;

	treeAPos = new Vector3 (-42, -4, (x + 85));
	GameObject treeFIns = Instantiate (treeA);
	treeFIns.transform.position = treeAPos;

	treeBPos = new Vector3 (40, -4, (x + 95));
	GameObject treeGIns = Instantiate (treeB);
	treeGIns.transform.position = treeBPos;


	treeBPos = new Vector3 (40, -4, (x + 100));
	GameObject treeHIns = Instantiate (treeB);
	treeHIns.transform.position = treeBPos;
	}
}
}