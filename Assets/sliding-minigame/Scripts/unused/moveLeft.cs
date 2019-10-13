using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour {

    public void Shift()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, transform.parent.position += new Vector3(-1, 0, 0), 1.0f);
    }
}
