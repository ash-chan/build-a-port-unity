using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsScreen : MonoBehaviour {
	public static int buttonTrigger;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		{
			if (InsScreen.buttonTrigger != 1) {
				if (transform.localScale.x < 1)
					transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f) * Time.deltaTime;		
			}
		}
		if (InsScreen.buttonTrigger == 1) 
		{
			if (transform.localScale.x > 0)
				transform.localScale -= new Vector3 (0.4f, 0.4f, 0.4f) * Time.deltaTime;
			
		}
	}

	public void OnPlayDeliveryDashClick() {

		InsScreen.buttonTrigger = 1;
		Debug.Log (rb.drag);

	}
}
