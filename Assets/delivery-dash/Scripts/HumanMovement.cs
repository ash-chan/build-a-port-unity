using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour {

	public Rigidbody human;
	int firstRand;

	// Use this for initialization
	void Start () {
		firstRand = Random.Range (1, 5);

		if (human.transform.position.x > 0)
		{
			if (firstRand == 1)
				human.velocity = new Vector3 (-20, 0, 0);

			if (firstRand == 2)
				human.velocity = new Vector3 (-25, 0, 0);

			if (firstRand == 3)
				human.velocity = new Vector3 (-30, 0, 0);

			if (firstRand == 4)
				human.velocity = new Vector3 (-35, 0, 0);

		}	

		if (human.transform.position.x < 0)
		{
			if (firstRand == 1)
				human.velocity = new Vector3 (20, 0, 0);

			if (firstRand == 2)
				human.velocity = new Vector3 (25, 0, 0);

			if (firstRand == 3)
				human.velocity = new Vector3 (30, 0, 0);

			if (firstRand == 4)
				human.velocity = new Vector3 (35, 0, 0);
		}	
		if (human.velocity.z < 0)
			human.AddForce ( new Vector3 (0, 0, -10));


	}


	// Update is called once per frame
	void Update () {
		
		
	}


}
