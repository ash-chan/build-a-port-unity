using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragZ : MonoBehaviour {


    private Vector3 screenPoint;
    private Vector3 offset;
    bool col = false;
    public bool select = false;

    private void OnTriggerStay(Collider other)
    {
        col = true;
    }

    private void OnTriggerExit(Collider other)
    {
        col = false;
    }


    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp()
    {
        col = false;
        select = false;
    }

    void OnMouseDrag()
    {
        select = true;
        if (col == false)
        {
            Vector3 curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = Vector3.MoveTowards(transform.position, curPosition, 1.5f * Time.deltaTime);
        }
    }
}
