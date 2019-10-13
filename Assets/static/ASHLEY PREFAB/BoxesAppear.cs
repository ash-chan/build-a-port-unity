using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BoxesAppear : MonoBehaviour {

	public GameObject redBox;
	public GameObject blueBox;
	public GameObject greenBox;
	public GameObject brownBox;
	public GameObject purpleBox;

	void Start () {
		InvokeRepeating ("CreateRedBox1", 0.0f, Random.Range (5f, 7f));
		InvokeRepeating ("CreateRedBox2", 1.0f, Random.Range (4f, 5f));
		InvokeRepeating ("CreateRedBox3", 0.0f, Random.Range (5f, 7f));
		InvokeRepeating ("CreateRedBox4", 1.0f, Random.Range (4f, 5f));
		InvokeRepeating ("CreateBlueBox1", 2.0f, Random.Range (3f, 6f));
		InvokeRepeating ("CreateBlueBox2", 3.0f, Random.Range (7f, 10f));
		InvokeRepeating ("CreateBlueBox3", 3.0f, Random.Range (7f, 10f));
		InvokeRepeating ("CreateBlueBox4", 3.0f, Random.Range (7f, 10f));
		//if (SaveState.truckOne == true) {
			InvokeRepeating ("CreateGreenBox1", 4.0f, Random.Range (4f, 8f));
			InvokeRepeating ("CreateGreenBox2", 5.0f, Random.Range (8f, 9f));
		//}
		//if (SaveState.yardCraneOne == true) {
			InvokeRepeating ("CreateBrownBox1", 6.0f, Random.Range (4f, 6f));
			InvokeRepeating ("CreateBrownBox2", 7.0f, Random.Range (3f, 4f));
		//}
		//if (SaveState.quaytwo == true) {
			InvokeRepeating ("CreatePurpleBox1", 8.0f, Random.Range (7f, 10f));
			InvokeRepeating ("CreatePurpleBox2", 9.0f, Random.Range (8f, 10f));
		//}
	}

	void Update() {
	}

	private void CreateRedBox1 () {
		GameObject redbox = Instantiate (redBox);
		redbox.transform.position = new Vector3 (40, 0, 10);
	}
	private void CreateRedBox2 () {
		GameObject redbox = Instantiate (redBox);
		redbox.transform.position = new Vector3 (40, 0, 20);
	}
	private void CreateRedBox3 () {
		GameObject redbox = Instantiate (redBox);
		redbox.transform.position = new Vector3 (80, 0, -40);
	}
	private void CreateRedBox4 () {
		GameObject redbox = Instantiate (redBox);
		redbox.transform.position = new Vector3 (85, 0, -30);
	}
	private void CreateBlueBox1 () {
		GameObject bluebox = Instantiate (blueBox);
		bluebox.transform.position = new Vector3 (50, 0, 10);
	}
	private void CreateBlueBox2 () {
		GameObject bluebox = Instantiate (blueBox);
		bluebox.transform.position = new Vector3 (40, 0, 15);
	}
	private void CreateBlueBox3 () {
		GameObject bluebox = Instantiate (blueBox);
		bluebox.transform.position = new Vector3 (60, 0, -20);
	}
	private void CreateBlueBox4 () {
		GameObject bluebox = Instantiate (blueBox);
		bluebox.transform.position = new Vector3 (90, 0, -25);
	}
	private void CreateGreenBox1 () {
		GameObject greenbox = Instantiate (greenBox);
		greenbox.transform.position = new Vector3 (70, 0, 10);
	}
	private void CreateGreenBox2 () {
		GameObject greenbox = Instantiate (greenBox);
		greenbox.transform.position = new Vector3 (75, 0, -25);
	}
	private void CreateBrownBox1 () {
		GameObject greenbox = Instantiate (brownBox);
		greenbox.transform.position = new Vector3 (85, 0, 10);
	}
	private void CreateBrownBox2 () {
		GameObject greenbox = Instantiate (brownBox);
		greenbox.transform.position = new Vector3 (65, 0, -30);
	}
	private void CreatePurpleBox1 () {
		GameObject greenbox = Instantiate (purpleBox);
		greenbox.transform.position = new Vector3 (72, 0, -42);
	}
	private void CreatePurpleBox2 () {
		GameObject greenbox = Instantiate (purpleBox);
		greenbox.transform.position = new Vector3 (90, 0, 25);
	}
		

	private void DetectClick (){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast (ray, out hit)) 
			if(hit.collider.tag == "redbox") 
				print ("You clicked on RedBox");
	}
	public void OnMouseDown(PointerEventData eventData) {
		Debug.Log ("Clicked redbox");
	}
}
