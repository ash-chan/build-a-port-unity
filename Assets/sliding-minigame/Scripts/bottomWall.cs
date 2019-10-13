using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomWall : MonoBehaviour {

    bool col = false, select = false;

    void OnTriggerEnter()
    {
        col = true;
    }

    void Update()
    {
        select = GetComponentInParent<DragZ>().select;
        if (col == true && select == true)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, transform.parent.position += new Vector3(0f, 0f, 0.06f), 1.0f);
            col = false;
        }
    }
}
