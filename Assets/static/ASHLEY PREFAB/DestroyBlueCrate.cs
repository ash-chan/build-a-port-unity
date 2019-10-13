using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlueCrate : MonoBehaviour {

	void OnMouseDown () {
		Money.currentMoney += 50;
		Destroy (gameObject);
	}
}
