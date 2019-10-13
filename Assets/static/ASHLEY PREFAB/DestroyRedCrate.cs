using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRedCrate : MonoBehaviour {

	void OnMouseDown () {
		Money.currentMoney += 25;
		Destroy (gameObject);
	}
}
