using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal1_1 : MonoBehaviour {

    //public Rigidbody Target, H2, H3, V2, V3, Goal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Target" || other.name == "Target(Clone)")
        {
            GetComponentInParent<Timer>().goal = true;
        }
    }
}
