using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrownCrate : MonoBehaviour {

	void OnMouseDown () {
		Money.currentMoney += 100;
		Destroy (gameObject);
	}
}
