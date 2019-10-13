using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject car;
	Vector3 shouldPos;

	
	// Update is called once per frame
	void Update () 
	{
		/*shouldPos = Vector3.Lerp (gameObject.transform.position, car.transform.position, Time.deltaTime);
		GameObject.transform.position = new Vector3 (shouldPos.x, 1, shouldPos.z);*/
	}
}
