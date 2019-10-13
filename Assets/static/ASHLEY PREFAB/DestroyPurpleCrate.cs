using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPurpleCrate : MonoBehaviour {

	void OnMouseDown () {
		Money.currentMoney += 150;
		Destroy (gameObject);
	}
}
