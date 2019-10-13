using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	AudioSource audioSource;
	Vector3 intPos=new Vector3(0,0,0);
	public Rigidbody rb;

	public AudioClip brake;

	public KeyCode keyL;
	public KeyCode keyR;
	public KeyCode keyU;
	public KeyCode keyD;

	// Use this for initialization
	void Start () {

		rb.velocity = new Vector3 (0, 0, 0);
		InsScreen.buttonTrigger = 0;
		CarCollision.endTrigger = 0;
	}

	// Update is called once per frame
	void Update () {
		
			
		if (InsScreen.buttonTrigger != 1)
			return;
		//Move forward/backwards

		if (rb.transform.position.z<1750)
		{
			if (Input.GetKey(keyU)) 
		{
			rb.AddRelativeForce (new Vector3 (0, 0, 1) * 70);
		} 

		else if (Input.GetKey(keyD)) 
		{
			rb.AddRelativeForce (new Vector3 (0, 0, -1) * 70);
		}

		//Turn left/right

		if (Input.GetKey (keyL)) 
		{
			rb.AddRelativeForce (new Vector3 (-1, 0, 0) * 100);
		} 
		else if (Input.GetKey (keyR)) 
		{
			rb.AddRelativeForce (new Vector3 (1, 0, 0) * 100);
		}	
		

		//artificial friction
		if (rb.velocity.x>0)
		{
			rb.AddForce (new Vector3 (-50, 0, 0));
		}
		if (rb.velocity.x<0)
		{
			rb.AddForce (new Vector3 (50, 0, 0));
		}
		if (rb.velocity.z>0)
		{
			rb.AddForce (new Vector3 (0, 0, -20));
		}
		if (rb.velocity.z<0)
		{
			rb.AddForce (new Vector3 (0, 0, 10));
		}
		}
		if (rb.transform.position.z > 1750 && rb.transform.position.z<1800) 
		{
			if (rb.velocity.z > 20)
				rb.AddForce (new Vector3 (0, 0, -200));
			if (rb.velocity.z < 20)
				rb.AddForce (new Vector3 (0, 0, 200));
			if (rb.velocity.x > 0)
				rb.AddForce (new Vector3 (-100, 0,0));
			if (rb.velocity.x < 0)
				rb.AddForce (new Vector3 (100, 0,0));
			
		}
		if (rb.transform.position.z >= 1800) 
		{
			rb.velocity = new Vector3 (0,0,0);
			CarCollision.endTrigger = 1;
		}

	

}
}