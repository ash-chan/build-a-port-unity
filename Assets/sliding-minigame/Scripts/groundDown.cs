using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0f, -0.01f, 0f), 5f);
    }

}
