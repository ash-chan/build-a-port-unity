using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {

	public static int endTrigger;



	void OnTriggerEnter(Collider Col)
	{	
		
		if (Col.tag == "Tree" || Col.tag =="Roadblock"||Col.tag=="Human") 
		{
			Debug.Log ("crash");
			Col.gameObject.GetComponent<Rigidbody>().velocity= new Vector3 (0, 0, 0);
			gameObject.GetComponent<BoxCollider>().size = new Vector3(300,10,300);
			gameObject.GetComponentInParent<Rigidbody>().velocity= new Vector3 (0, 0, 0);
			gameObject.GetComponentInParent<Rigidbody>().drag= 100;
			endTrigger=1;
				
			Debug.Log(endTrigger);

		}
	}
}
