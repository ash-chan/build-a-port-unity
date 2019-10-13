using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGreenCrate : MonoBehaviour {

	void OnMouseDown () {
		Money.currentMoney += 80;
		Destroy (gameObject);
	}
}
