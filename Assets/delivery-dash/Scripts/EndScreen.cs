using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {
	public Text timerText;
	public Text distanceText;
	public Text moneyText;
	static public float DDMoney;
	public Rigidbody truck;
	public float time;
	float counter = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (CarCollision.endTrigger!=1)
		time += Time.deltaTime;

		if (CarCollision.endTrigger == 1) {
			if (counter < 5) {
				if (transform.localScale.x < 1)
					transform.localScale += new Vector3 (0.4f, 0.4f, 0.4f) * Time.deltaTime;
			}
			timerText.text = time.ToString ()+" Seconds";
			distanceText.text = truck.transform.position.z.ToString ()+" Metres";
			if (truck.transform.position.z > 1750)
				DDMoney = ((600 - time) + 2000);
			else
				DDMoney = truck.transform.position.z;
			moneyText.text = "$"+DDMoney.ToString ();

			counter += Time.deltaTime;
		}
	}
}
