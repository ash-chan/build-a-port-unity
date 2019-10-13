using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObs : MonoBehaviour {

	void OnTriggerEnter(Collider Col)
	{
		Destroy (Col.gameObject);
	}
}
