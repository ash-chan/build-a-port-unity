using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOn : MonoBehaviour {



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 50.0f);
            if (didHit)
            {
                moveRight destScript = rhInfo.collider.GetComponent<moveRight>();
                if(destScript)
                {
                    destScript.Shift();
                }
            }
        }
    }
}
